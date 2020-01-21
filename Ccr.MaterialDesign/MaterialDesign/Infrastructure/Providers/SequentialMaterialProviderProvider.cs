using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public class SequentialMaterialProviderProvider 
		: IMaterialProviderProvider
	{
		#region Properties
		public List<IMaterialProvider> MaterialProviderSequence { get; }

		public CyclicalBehavior CyclicalMode { get; }

		public bool Reverse { get; set; }

		#endregion


		#region Fields
		private MirrorDirection _mirrorDirection = MirrorDirection.Forward;
		private int _currentIndex;

		#endregion


		#region Constructors
		public SequentialMaterialProviderProvider()
			: this(
				new List<IMaterialProvider>())
		{
		}

		public SequentialMaterialProviderProvider(
			params IMaterialProvider[] materialSetSequence)
				: this(CyclicalBehavior.Repeat, materialSetSequence)
		{
		}

		public SequentialMaterialProviderProvider(
			IList<IMaterialProvider> materialSetSequence)
				: this(CyclicalBehavior.Repeat, materialSetSequence)
		{
		}

		public SequentialMaterialProviderProvider(
			CyclicalBehavior mode = CyclicalBehavior.Repeat,
			params IMaterialProvider[] materialSetSequence)
				: this(mode, materialSetSequence.ToList())
		{
		}

		public SequentialMaterialProviderProvider(
			CyclicalBehavior mode, 
			IList<IMaterialProvider> materialSetSequence)
		{
			MaterialProviderSequence = new List<IMaterialProvider>(materialSetSequence);
			CyclicalMode = mode;
		}

		#endregion


		#region Methods
		public IMaterialProvider ProvideNext(ProviderContext context)
		{
			switch (CyclicalMode)
			{
				case CyclicalBehavior.Repeat:
					{
						if (_currentIndex > MaterialProviderSequence.Count - 1)
							_currentIndex = 0;
						if (_currentIndex < 0)
							_currentIndex = MaterialProviderSequence.Count - 1;

						var currentSet = MaterialProviderSequence[_currentIndex];
						if (Reverse)
							_currentIndex--;
						else
							_currentIndex++;
						return currentSet;
					}
				case CyclicalBehavior.Mirror:
					{
						if (_currentIndex > MaterialProviderSequence.Count - 1)
						{
							_currentIndex = MaterialProviderSequence.Count - 2;
							_mirrorDirection = MirrorDirection.Backward;
						}
						else if (_currentIndex < 0)
						{
							_currentIndex = 1;
							_mirrorDirection = MirrorDirection.Forward;
						}
						var currentSet = MaterialProviderSequence[_currentIndex];

						switch (_mirrorDirection)
						{
							case MirrorDirection.Forward:
								_currentIndex++;
								break;
							case MirrorDirection.Backward:
								_currentIndex--;
								break;
						}
						return currentSet;
					}
				default:
					throw new NotSupportedException(
						$"Cyclical Mode {CyclicalMode} is not supported.");
			}
		}

		public void Reset(ProviderContext context)
		{
			if (Reverse)
				_currentIndex = context.CycleLength - 1;
			else
				_currentIndex = 0;
		}
		#endregion
	}
}
