//using System.Windows.Media;
//using Ccr.MaterialDesign.Static;

//namespace Ccr.MaterialDesign.DesignTime
//{
//  public static class PaletteMock
//  {
//    internal static class Colors
//    {
//      internal static readonly Color c_Transparent = Color.FromArgb(0, 255, 255, 255);
//      internal static readonly Color c_White = Color.FromRgb(255, 255, 255);
//      internal static readonly Color c_Black = Color.FromRgb(0, 0, 0);

//      internal static readonly Color c_Red050 = Color.FromRgb(255, 235, 238);
//      internal static readonly Color c_Red100 = Color.FromRgb(255, 205, 210);
//      internal static readonly Color c_Red200 = Color.FromRgb(239, 154, 154);
//      internal static readonly Color c_Red300 = Color.FromRgb(229, 115, 115);
//      internal static readonly Color c_Red400 = Color.FromRgb(239, 83, 80);
//      internal static readonly Color c_Red500 = Color.FromRgb(244, 67, 54);
//      internal static readonly Color c_Red600 = Color.FromRgb(229, 57, 53);
//      internal static readonly Color c_Red700 = Color.FromRgb(211, 47, 47);
//      internal static readonly Color c_Red800 = Color.FromRgb(198, 40, 40);
//      internal static readonly Color c_Red900 = Color.FromRgb(183, 28, 28);
//      internal static readonly Color c_RedA100 = Color.FromRgb(255, 138, 128);
//      internal static readonly Color c_RedA200 = Color.FromRgb(255, 82, 82);
//      internal static readonly Color c_RedA400 = Color.FromRgb(255, 23, 68);
//      internal static readonly Color c_RedA700 = Color.FromRgb(213, 0, 0);

//      internal static readonly Color c_Pink050 = Color.FromRgb(252, 228, 236);
//      internal static readonly Color c_Pink100 = Color.FromRgb(248, 187, 208);
//      internal static readonly Color c_Pink200 = Color.FromRgb(244, 143, 177);
//      internal static readonly Color c_Pink300 = Color.FromRgb(240, 98, 146);
//      internal static readonly Color c_Pink400 = Color.FromRgb(236, 64, 122);
//      internal static readonly Color c_Pink500 = Color.FromRgb(233, 30, 99);
//      internal static readonly Color c_Pink600 = Color.FromRgb(216, 27, 96);
//      internal static readonly Color c_Pink700 = Color.FromRgb(194, 24, 91);
//      internal static readonly Color c_Pink800 = Color.FromRgb(173, 20, 87);
//      internal static readonly Color c_Pink900 = Color.FromRgb(136, 14, 79);
//      internal static readonly Color c_PinkA100 = Color.FromRgb(255, 128, 171);
//      internal static readonly Color c_PinkA200 = Color.FromRgb(255, 64, 129);
//      internal static readonly Color c_PinkA400 = Color.FromRgb(245, 0, 87);
//      internal static readonly Color c_PinkA700 = Color.FromRgb(197, 17, 98);

//      internal static readonly Color c_Purple050 = Color.FromRgb(243, 229, 245);
//      internal static readonly Color c_Purple100 = Color.FromRgb(225, 190, 231);
//      internal static readonly Color c_Purple200 = Color.FromRgb(206, 147, 216);
//      internal static readonly Color c_Purple300 = Color.FromRgb(186, 104, 200);
//      internal static readonly Color c_Purple400 = Color.FromRgb(171, 71, 188);
//      internal static readonly Color c_Purple500 = Color.FromRgb(156, 39, 176);
//      internal static readonly Color c_Purple600 = Color.FromRgb(142, 36, 170);
//      internal static readonly Color c_Purple700 = Color.FromRgb(123, 31, 162);
//      internal static readonly Color c_Purple800 = Color.FromRgb(106, 27, 154);
//      internal static readonly Color c_Purple900 = Color.FromRgb(74, 20, 140);
//      internal static readonly Color c_PurpleA100 = Color.FromRgb(234, 128, 252);
//      internal static readonly Color c_PurpleA200 = Color.FromRgb(224, 64, 251);
//      internal static readonly Color c_PurpleA400 = Color.FromRgb(213, 0, 249);
//      internal static readonly Color c_PurpleA700 = Color.FromRgb(170, 0, 255);

//      internal static readonly Color c_DeepPurple050 = Color.FromRgb(237, 231, 246);
//      internal static readonly Color c_DeepPurple100 = Color.FromRgb(209, 196, 233);
//      internal static readonly Color c_DeepPurple200 = Color.FromRgb(179, 157, 219);
//      internal static readonly Color c_DeepPurple300 = Color.FromRgb(149, 117, 205);
//      internal static readonly Color c_DeepPurple400 = Color.FromRgb(126, 87, 194);
//      internal static readonly Color c_DeepPurple500 = Color.FromRgb(103, 58, 183);
//      internal static readonly Color c_DeepPurple600 = Color.FromRgb(94, 53, 177);
//      internal static readonly Color c_DeepPurple700 = Color.FromRgb(81, 45, 168);
//      internal static readonly Color c_DeepPurple800 = Color.FromRgb(69, 39, 160);
//      internal static readonly Color c_DeepPurple900 = Color.FromRgb(49, 27, 146);
//      internal static readonly Color c_DeepPurpleA100 = Color.FromRgb(179, 136, 255);
//      internal static readonly Color c_DeepPurpleA200 = Color.FromRgb(124, 77, 255);
//      internal static readonly Color c_DeepPurpleA400 = Color.FromRgb(101, 31, 255);
//      internal static readonly Color c_DeepPurpleA700 = Color.FromRgb(98, 0, 234);

//      internal static readonly Color c_Indigo050 = Color.FromRgb(232, 234, 246);
//      internal static readonly Color c_Indigo100 = Color.FromRgb(197, 202, 233);
//      internal static readonly Color c_Indigo200 = Color.FromRgb(159, 168, 218);
//      internal static readonly Color c_Indigo300 = Color.FromRgb(121, 134, 203);
//      internal static readonly Color c_Indigo400 = Color.FromRgb(92, 107, 192);
//      internal static readonly Color c_Indigo500 = Color.FromRgb(63, 81, 181);
//      internal static readonly Color c_Indigo600 = Color.FromRgb(57, 73, 171);
//      internal static readonly Color c_Indigo700 = Color.FromRgb(48, 63, 159);
//      internal static readonly Color c_Indigo800 = Color.FromRgb(40, 53, 147);
//      internal static readonly Color c_Indigo900 = Color.FromRgb(26, 35, 126);
//      internal static readonly Color c_IndigoA100 = Color.FromRgb(140, 158, 255);
//      internal static readonly Color c_IndigoA200 = Color.FromRgb(83, 109, 254);
//      internal static readonly Color c_IndigoA400 = Color.FromRgb(61, 90, 254);
//      internal static readonly Color c_IndigoA700 = Color.FromRgb(48, 79, 254);

//      internal static readonly Color c_Blue050 = Color.FromRgb(227, 242, 253);
//      internal static readonly Color c_Blue100 = Color.FromRgb(187, 222, 251);
//      internal static readonly Color c_Blue200 = Color.FromRgb(144, 202, 249);
//      internal static readonly Color c_Blue300 = Color.FromRgb(100, 181, 246);
//      internal static readonly Color c_Blue400 = Color.FromRgb(66, 165, 245);
//      internal static readonly Color c_Blue500 = Color.FromRgb(33, 150, 243);
//      internal static readonly Color c_Blue600 = Color.FromRgb(30, 136, 229);
//      internal static readonly Color c_Blue700 = Color.FromRgb(25, 118, 210);
//      internal static readonly Color c_Blue800 = Color.FromRgb(21, 101, 192);
//      internal static readonly Color c_Blue900 = Color.FromRgb(13, 71, 161);
//      internal static readonly Color c_BlueA100 = Color.FromRgb(130, 177, 255);
//      internal static readonly Color c_BlueA200 = Color.FromRgb(68, 138, 255);
//      internal static readonly Color c_BlueA400 = Color.FromRgb(41, 121, 255);
//      internal static readonly Color c_BlueA700 = Color.FromRgb(41, 98, 255);

//      internal static readonly Color c_LightBlue050 = Color.FromRgb(225, 245, 254);
//      internal static readonly Color c_LightBlue100 = Color.FromRgb(179, 229, 252);
//      internal static readonly Color c_LightBlue200 = Color.FromRgb(129, 212, 250);
//      internal static readonly Color c_LightBlue300 = Color.FromRgb(79, 195, 247);
//      internal static readonly Color c_LightBlue400 = Color.FromRgb(41, 182, 246);
//      internal static readonly Color c_LightBlue500 = Color.FromRgb(3, 169, 244);
//      internal static readonly Color c_LightBlue600 = Color.FromRgb(3, 155, 229);
//      internal static readonly Color c_LightBlue700 = Color.FromRgb(2, 136, 209);
//      internal static readonly Color c_LightBlue800 = Color.FromRgb(2, 119, 189);
//      internal static readonly Color c_LightBlue900 = Color.FromRgb(1, 87, 155);
//      internal static readonly Color c_LightBlueA100 = Color.FromRgb(128, 216, 255);
//      internal static readonly Color c_LightBlueA200 = Color.FromRgb(64, 196, 255);
//      internal static readonly Color c_LightBlueA400 = Color.FromRgb(0, 176, 255);
//      internal static readonly Color c_LightBlueA700 = Color.FromRgb(0, 145, 234);

//      internal static readonly Color c_Cyan050 = Color.FromRgb(224, 247, 250);
//      internal static readonly Color c_Cyan100 = Color.FromRgb(178, 235, 242);
//      internal static readonly Color c_Cyan200 = Color.FromRgb(128, 222, 234);
//      internal static readonly Color c_Cyan300 = Color.FromRgb(77, 208, 225);
//      internal static readonly Color c_Cyan400 = Color.FromRgb(38, 198, 218);
//      internal static readonly Color c_Cyan500 = Color.FromRgb(0, 188, 212);
//      internal static readonly Color c_Cyan600 = Color.FromRgb(0, 172, 193);
//      internal static readonly Color c_Cyan700 = Color.FromRgb(0, 151, 167);
//      internal static readonly Color c_Cyan800 = Color.FromRgb(0, 131, 143);
//      internal static readonly Color c_Cyan900 = Color.FromRgb(0, 96, 100);
//      internal static readonly Color c_CyanA100 = Color.FromRgb(132, 255, 255);
//      internal static readonly Color c_CyanA200 = Color.FromRgb(24, 255, 255);
//      internal static readonly Color c_CyanA400 = Color.FromRgb(0, 229, 255);
//      internal static readonly Color c_CyanA700 = Color.FromRgb(0, 184, 212);

//      internal static readonly Color c_Teal050 = Color.FromRgb(224, 242, 241);
//      internal static readonly Color c_Teal100 = Color.FromRgb(178, 223, 219);
//      internal static readonly Color c_Teal200 = Color.FromRgb(128, 203, 196);
//      internal static readonly Color c_Teal300 = Color.FromRgb(77, 182, 172);
//      internal static readonly Color c_Teal400 = Color.FromRgb(38, 166, 154);
//      internal static readonly Color c_Teal500 = Color.FromRgb(0, 150, 136);
//      internal static readonly Color c_Teal600 = Color.FromRgb(0, 137, 123);
//      internal static readonly Color c_Teal700 = Color.FromRgb(0, 121, 107);
//      internal static readonly Color c_Teal800 = Color.FromRgb(0, 105, 92);
//      internal static readonly Color c_Teal900 = Color.FromRgb(0, 77, 64);
//      internal static readonly Color c_TealA100 = Color.FromRgb(167, 255, 235);
//      internal static readonly Color c_TealA200 = Color.FromRgb(100, 255, 218);
//      internal static readonly Color c_TealA400 = Color.FromRgb(29, 233, 182);
//      internal static readonly Color c_TealA700 = Color.FromRgb(0, 191, 165);

//      internal static readonly Color c_Green050 = Color.FromRgb(232, 245, 233);
//      internal static readonly Color c_Green100 = Color.FromRgb(200, 230, 201);
//      internal static readonly Color c_Green200 = Color.FromRgb(165, 214, 167);
//      internal static readonly Color c_Green300 = Color.FromRgb(129, 199, 132);
//      internal static readonly Color c_Green400 = Color.FromRgb(102, 187, 106);
//      internal static readonly Color c_Green500 = Color.FromRgb(76, 175, 80);
//      internal static readonly Color c_Green600 = Color.FromRgb(67, 160, 71);
//      internal static readonly Color c_Green700 = Color.FromRgb(56, 142, 60);
//      internal static readonly Color c_Green800 = Color.FromRgb(46, 125, 050);
//      internal static readonly Color c_Green900 = Color.FromRgb(27, 94, 32);
//      internal static readonly Color c_GreenA100 = Color.FromRgb(185, 246, 202);
//      internal static readonly Color c_GreenA200 = Color.FromRgb(105, 240, 174);
//      internal static readonly Color c_GreenA400 = Color.FromRgb(0, 230, 118);
//      internal static readonly Color c_GreenA700 = Color.FromRgb(0, 200, 83);

//      internal static readonly Color c_LightGreen050 = Color.FromRgb(241, 248, 233);
//      internal static readonly Color c_LightGreen100 = Color.FromRgb(220, 237, 200);
//      internal static readonly Color c_LightGreen200 = Color.FromRgb(197, 225, 165);
//      internal static readonly Color c_LightGreen300 = Color.FromRgb(174, 213, 129);
//      internal static readonly Color c_LightGreen400 = Color.FromRgb(156, 204, 101);
//      internal static readonly Color c_LightGreen500 = Color.FromRgb(139, 195, 74);
//      internal static readonly Color c_LightGreen600 = Color.FromRgb(124, 179, 66);
//      internal static readonly Color c_LightGreen700 = Color.FromRgb(104, 159, 56);
//      internal static readonly Color c_LightGreen800 = Color.FromRgb(85, 139, 47);
//      internal static readonly Color c_LightGreen900 = Color.FromRgb(51, 105, 30);
//      internal static readonly Color c_LightGreenA100 = Color.FromRgb(204, 255, 144);
//      internal static readonly Color c_LightGreenA200 = Color.FromRgb(178, 255, 89);
//      internal static readonly Color c_LightGreenA400 = Color.FromRgb(118, 255, 3);
//      internal static readonly Color c_LightGreenA700 = Color.FromRgb(100, 221, 23);

//      internal static readonly Color c_Lime050 = Color.FromRgb(249, 251, 231);
//      internal static readonly Color c_Lime100 = Color.FromRgb(240, 244, 195);
//      internal static readonly Color c_Lime200 = Color.FromRgb(230, 238, 156);
//      internal static readonly Color c_Lime300 = Color.FromRgb(220, 231, 117);
//      internal static readonly Color c_Lime400 = Color.FromRgb(212, 225, 87);
//      internal static readonly Color c_Lime500 = Color.FromRgb(205, 220, 57);
//      internal static readonly Color c_Lime600 = Color.FromRgb(192, 202, 51);
//      internal static readonly Color c_Lime700 = Color.FromRgb(175, 180, 43);
//      internal static readonly Color c_Lime800 = Color.FromRgb(158, 157, 36);
//      internal static readonly Color c_Lime900 = Color.FromRgb(130, 119, 23);
//      internal static readonly Color c_LimeA100 = Color.FromRgb(244, 255, 129);
//      internal static readonly Color c_LimeA200 = Color.FromRgb(238, 255, 65);
//      internal static readonly Color c_LimeA400 = Color.FromRgb(198, 255, 0);
//      internal static readonly Color c_LimeA700 = Color.FromRgb(174, 234, 0);

//      internal static readonly Color c_Yellow050 = Color.FromRgb(255, 253, 231);
//      internal static readonly Color c_Yellow100 = Color.FromRgb(255, 249, 196);
//      internal static readonly Color c_Yellow200 = Color.FromRgb(255, 245, 157);
//      internal static readonly Color c_Yellow300 = Color.FromRgb(255, 241, 118);
//      internal static readonly Color c_Yellow400 = Color.FromRgb(255, 238, 88);
//      internal static readonly Color c_Yellow500 = Color.FromRgb(255, 235, 59);
//      internal static readonly Color c_Yellow600 = Color.FromRgb(253, 216, 53);
//      internal static readonly Color c_Yellow700 = Color.FromRgb(251, 192, 45);
//      internal static readonly Color c_Yellow800 = Color.FromRgb(249, 168, 37);
//      internal static readonly Color c_Yellow900 = Color.FromRgb(245, 127, 23);
//      internal static readonly Color c_YellowA100 = Color.FromRgb(255, 255, 141);
//      internal static readonly Color c_YellowA200 = Color.FromRgb(255, 255, 0);
//      internal static readonly Color c_YellowA400 = Color.FromRgb(255, 234, 0);
//      internal static readonly Color c_YellowA700 = Color.FromRgb(255, 214, 0);

//      internal static readonly Color c_Amber050 = Color.FromRgb(255, 248, 225);
//      internal static readonly Color c_Amber100 = Color.FromRgb(255, 236, 179);
//      internal static readonly Color c_Amber200 = Color.FromRgb(255, 224, 130);
//      internal static readonly Color c_Amber300 = Color.FromRgb(255, 213, 79);
//      internal static readonly Color c_Amber400 = Color.FromRgb(255, 202, 40);
//      internal static readonly Color c_Amber500 = Color.FromRgb(255, 193, 7);
//      internal static readonly Color c_Amber600 = Color.FromRgb(255, 179, 0);
//      internal static readonly Color c_Amber700 = Color.FromRgb(255, 160, 0);
//      internal static readonly Color c_Amber800 = Color.FromRgb(255, 143, 0);
//      internal static readonly Color c_Amber900 = Color.FromRgb(255, 111, 0);
//      internal static readonly Color c_AmberA100 = Color.FromRgb(255, 229, 127);
//      internal static readonly Color c_AmberA200 = Color.FromRgb(255, 215, 64);
//      internal static readonly Color c_AmberA400 = Color.FromRgb(255, 196, 0);
//      internal static readonly Color c_AmberA700 = Color.FromRgb(255, 171, 0);

//      internal static readonly Color c_Orange050 = Color.FromRgb(255, 243, 224);
//      internal static readonly Color c_Orange100 = Color.FromRgb(255, 224, 178);
//      internal static readonly Color c_Orange200 = Color.FromRgb(255, 204, 128);
//      internal static readonly Color c_Orange300 = Color.FromRgb(255, 183, 77);
//      internal static readonly Color c_Orange400 = Color.FromRgb(255, 167, 38);
//      internal static readonly Color c_Orange500 = Color.FromRgb(255, 152, 0);
//      internal static readonly Color c_Orange600 = Color.FromRgb(251, 140, 0);
//      internal static readonly Color c_Orange700 = Color.FromRgb(245, 124, 0);
//      internal static readonly Color c_Orange800 = Color.FromRgb(239, 108, 0);
//      internal static readonly Color c_Orange900 = Color.FromRgb(230, 81, 0);
//      internal static readonly Color c_OrangeA100 = Color.FromRgb(255, 209, 128);
//      internal static readonly Color c_OrangeA200 = Color.FromRgb(255, 171, 64);
//      internal static readonly Color c_OrangeA400 = Color.FromRgb(255, 145, 0);
//      internal static readonly Color c_OrangeA700 = Color.FromRgb(255, 109, 0);

//      internal static readonly Color c_DeepOrange050 = Color.FromRgb(251, 233, 231);
//      internal static readonly Color c_DeepOrange100 = Color.FromRgb(255, 204, 188);
//      internal static readonly Color c_DeepOrange200 = Color.FromRgb(255, 171, 145);
//      internal static readonly Color c_DeepOrange300 = Color.FromRgb(255, 138, 101);
//      internal static readonly Color c_DeepOrange400 = Color.FromRgb(255, 112, 67);
//      internal static readonly Color c_DeepOrange500 = Color.FromRgb(255, 87, 34);
//      internal static readonly Color c_DeepOrange600 = Color.FromRgb(244, 81, 30);
//      internal static readonly Color c_DeepOrange700 = Color.FromRgb(230, 74, 25);
//      internal static readonly Color c_DeepOrange800 = Color.FromRgb(216, 67, 21);
//      internal static readonly Color c_DeepOrange900 = Color.FromRgb(191, 54, 12);
//      internal static readonly Color c_DeepOrangeA100 = Color.FromRgb(255, 158, 128);
//      internal static readonly Color c_DeepOrangeA200 = Color.FromRgb(255, 110, 64);
//      internal static readonly Color c_DeepOrangeA400 = Color.FromRgb(255, 61, 0);
//      internal static readonly Color c_DeepOrangeA700 = Color.FromRgb(221, 44, 0);

//      internal static readonly Color c_Brown050 = Color.FromRgb(239, 235, 233);
//      internal static readonly Color c_Brown100 = Color.FromRgb(215, 204, 200);
//      internal static readonly Color c_Brown200 = Color.FromRgb(188, 170, 164);
//      internal static readonly Color c_Brown300 = Color.FromRgb(161, 136, 127);
//      internal static readonly Color c_Brown400 = Color.FromRgb(141, 110, 99);
//      internal static readonly Color c_Brown500 = Color.FromRgb(121, 85, 72);
//      internal static readonly Color c_Brown600 = Color.FromRgb(109, 76, 65);
//      internal static readonly Color c_Brown700 = Color.FromRgb(93, 64, 55);
//      internal static readonly Color c_Brown800 = Color.FromRgb(78, 52, 46);
//      internal static readonly Color c_Brown900 = Color.FromRgb(62, 39, 35);

//      internal static readonly Color c_Grey050 = Color.FromRgb(250, 250, 250);
//      internal static readonly Color c_Grey100 = Color.FromRgb(245, 245, 245);
//      internal static readonly Color c_Grey200 = Color.FromRgb(238, 238, 238);
//      internal static readonly Color c_Grey300 = Color.FromRgb(224, 224, 224);
//      internal static readonly Color c_Grey400 = Color.FromRgb(189, 189, 189);
//      internal static readonly Color c_Grey500 = Color.FromRgb(158, 158, 158);
//      internal static readonly Color c_Grey600 = Color.FromRgb(117, 117, 117);
//      internal static readonly Color c_Grey700 = Color.FromRgb(97, 97, 97);
//      internal static readonly Color c_Grey800 = Color.FromRgb(66, 66, 66);
//      internal static readonly Color c_Grey900 = Color.FromRgb(33, 33, 33);

//      internal static readonly Color c_BlueGrey050 = Color.FromRgb(236, 239, 241);
//      internal static readonly Color c_BlueGrey100 = Color.FromRgb(207, 216, 220);
//      internal static readonly Color c_BlueGrey200 = Color.FromRgb(176, 190, 197);
//      internal static readonly Color c_BlueGrey300 = Color.FromRgb(144, 164, 174);
//      internal static readonly Color c_BlueGrey400 = Color.FromRgb(120, 144, 156);
//      internal static readonly Color c_BlueGrey500 = Color.FromRgb(96, 125, 139);
//      internal static readonly Color c_BlueGrey600 = Color.FromRgb(84, 110, 122);
//      internal static readonly Color c_BlueGrey700 = Color.FromRgb(69, 90, 100);
//      internal static readonly Color c_BlueGrey800 = Color.FromRgb(55, 71, 79);
//      internal static readonly Color c_BlueGrey900 = Color.FromRgb(38, 50, 56);
//    }

//    #region Materials
//    //public static readonly MaterialBrush White_000 = MaterialBrush.Create(Colors.c_White);
//    //public static readonly MaterialBrush Black_000 = MaterialBrush.Create(Colors.c_Black);
//    //public static readonly MaterialBrush Transparent000 = MaterialBrush.Create(Colors.c_Transparent);

//    public static readonly MaterialBrush Red_050 = MaterialBrush.Create(Colors.c_Red050);
//    public static readonly MaterialBrush Red_100 = MaterialBrush.Create(Colors.c_Red100);
//    public static readonly MaterialBrush Red_200 = MaterialBrush.Create(Colors.c_Red200);
//    public static readonly MaterialBrush Red_300 = MaterialBrush.Create(Colors.c_Red300);
//    public static readonly MaterialBrush Red_400 = MaterialBrush.Create(Colors.c_Red400);
//    public static readonly MaterialBrush Red_500 = MaterialBrush.Create(Colors.c_Red500);
//    public static readonly MaterialBrush Red_600 = MaterialBrush.Create(Colors.c_Red600);
//    public static readonly MaterialBrush Red_700 = MaterialBrush.Create(Colors.c_Red700);
//    public static readonly MaterialBrush Red_800 = MaterialBrush.Create(Colors.c_Red800);
//    public static readonly MaterialBrush Red_900 = MaterialBrush.Create(Colors.c_Red900);
//    public static readonly MaterialBrush Red_A100 = MaterialBrush.Create(Colors.c_RedA100);
//    public static readonly MaterialBrush Red_A200 = MaterialBrush.Create(Colors.c_RedA200);
//    public static readonly MaterialBrush Red_A400 = MaterialBrush.Create(Colors.c_RedA400);
//    public static readonly MaterialBrush Red_A700 = MaterialBrush.Create(Colors.c_RedA700);

//    public static readonly MaterialBrush Pink_050 = MaterialBrush.Create(Colors.c_Pink050);
//    public static readonly MaterialBrush Pink_100 = MaterialBrush.Create(Colors.c_Pink100);
//    public static readonly MaterialBrush Pink_200 = MaterialBrush.Create(Colors.c_Pink200);
//    public static readonly MaterialBrush Pink_300 = MaterialBrush.Create(Colors.c_Pink300);
//    public static readonly MaterialBrush Pink_400 = MaterialBrush.Create(Colors.c_Pink400);
//    public static readonly MaterialBrush Pink_500 = MaterialBrush.Create(Colors.c_Pink500);
//    public static readonly MaterialBrush Pink_600 = MaterialBrush.Create(Colors.c_Pink600);
//    public static readonly MaterialBrush Pink_700 = MaterialBrush.Create(Colors.c_Pink700);
//    public static readonly MaterialBrush Pink_800 = MaterialBrush.Create(Colors.c_Pink800);
//    public static readonly MaterialBrush Pink_900 = MaterialBrush.Create(Colors.c_Pink900);
//    public static readonly MaterialBrush Pink_A100 = MaterialBrush.Create(Colors.c_PinkA100);
//    public static readonly MaterialBrush Pink_A200 = MaterialBrush.Create(Colors.c_PinkA200);
//    public static readonly MaterialBrush Pink_A400 = MaterialBrush.Create(Colors.c_PinkA400);
//    public static readonly MaterialBrush Pink_A700 = MaterialBrush.Create(Colors.c_PinkA700);

//    public static readonly MaterialBrush Purple_050 = MaterialBrush.Create(Colors.c_Purple050);
//    public static readonly MaterialBrush Purple_100 = MaterialBrush.Create(Colors.c_Purple100);
//    public static readonly MaterialBrush Purple_200 = MaterialBrush.Create(Colors.c_Purple200);
//    public static readonly MaterialBrush Purple_300 = MaterialBrush.Create(Colors.c_Purple300);
//    public static readonly MaterialBrush Purple_400 = MaterialBrush.Create(Colors.c_Purple400);
//    public static readonly MaterialBrush Purple_500 = MaterialBrush.Create(Colors.c_Purple500);
//    public static readonly MaterialBrush Purple_600 = MaterialBrush.Create(Colors.c_Purple600);
//    public static readonly MaterialBrush Purple_700 = MaterialBrush.Create(Colors.c_Purple700);
//    public static readonly MaterialBrush Purple_800 = MaterialBrush.Create(Colors.c_Purple800);
//    public static readonly MaterialBrush Purple_900 = MaterialBrush.Create(Colors.c_Purple900);
//    public static readonly MaterialBrush Purple_A100 = MaterialBrush.Create(Colors.c_PurpleA100);
//    public static readonly MaterialBrush Purple_A200 = MaterialBrush.Create(Colors.c_PurpleA200);
//    public static readonly MaterialBrush Purple_A400 = MaterialBrush.Create(Colors.c_PurpleA400);
//    public static readonly MaterialBrush Purple_A700 = MaterialBrush.Create(Colors.c_PurpleA700);

//    public static readonly MaterialBrush DeepPurple_050 = MaterialBrush.Create(Colors.c_DeepPurple050);
//    public static readonly MaterialBrush DeepPurple_100 = MaterialBrush.Create(Colors.c_DeepPurple100);
//    public static readonly MaterialBrush DeepPurple_200 = MaterialBrush.Create(Colors.c_DeepPurple200);
//    public static readonly MaterialBrush DeepPurple_300 = MaterialBrush.Create(Colors.c_DeepPurple300);
//    public static readonly MaterialBrush DeepPurple_400 = MaterialBrush.Create(Colors.c_DeepPurple400);
//    public static readonly MaterialBrush DeepPurple_500 = MaterialBrush.Create(Colors.c_DeepPurple500);
//    public static readonly MaterialBrush DeepPurple_600 = MaterialBrush.Create(Colors.c_DeepPurple600);
//    public static readonly MaterialBrush DeepPurple_700 = MaterialBrush.Create(Colors.c_DeepPurple700);
//    public static readonly MaterialBrush DeepPurple_800 = MaterialBrush.Create(Colors.c_DeepPurple800);
//    public static readonly MaterialBrush DeepPurple_900 = MaterialBrush.Create(Colors.c_DeepPurple900);
//    public static readonly MaterialBrush DeepPurple_A100 = MaterialBrush.Create(Colors.c_DeepPurpleA100);
//    public static readonly MaterialBrush DeepPurple_A200 = MaterialBrush.Create(Colors.c_DeepPurpleA200);
//    public static readonly MaterialBrush DeepPurple_A400 = MaterialBrush.Create(Colors.c_DeepPurpleA400);
//    public static readonly MaterialBrush DeepPurple_A700 = MaterialBrush.Create(Colors.c_DeepPurpleA700);

//    public static readonly MaterialBrush Indigo_050 = MaterialBrush.Create(Colors.c_Indigo050);
//    public static readonly MaterialBrush Indigo_100 = MaterialBrush.Create(Colors.c_Indigo100);
//    public static readonly MaterialBrush Indigo_200 = MaterialBrush.Create(Colors.c_Indigo200);
//    public static readonly MaterialBrush Indigo_300 = MaterialBrush.Create(Colors.c_Indigo300);
//    public static readonly MaterialBrush Indigo_400 = MaterialBrush.Create(Colors.c_Indigo400);
//    public static readonly MaterialBrush Indigo_500 = MaterialBrush.Create(Colors.c_Indigo500);
//    public static readonly MaterialBrush Indigo_600 = MaterialBrush.Create(Colors.c_Indigo600);
//    public static readonly MaterialBrush Indigo_700 = MaterialBrush.Create(Colors.c_Indigo700);
//    public static readonly MaterialBrush Indigo_800 = MaterialBrush.Create(Colors.c_Indigo800);
//    public static readonly MaterialBrush Indigo_900 = MaterialBrush.Create(Colors.c_Indigo900);
//    public static readonly MaterialBrush Indigo_A100 = MaterialBrush.Create(Colors.c_IndigoA100);
//    public static readonly MaterialBrush Indigo_A200 = MaterialBrush.Create(Colors.c_IndigoA200);
//    public static readonly MaterialBrush Indigo_A400 = MaterialBrush.Create(Colors.c_IndigoA400);
//    public static readonly MaterialBrush Indigo_A700 = MaterialBrush.Create(Colors.c_IndigoA700);

//    public static readonly MaterialBrush Blue_050 = MaterialBrush.Create(Colors.c_Blue050);
//    public static readonly MaterialBrush Blue_100 = MaterialBrush.Create(Colors.c_Blue100);
//    public static readonly MaterialBrush Blue_200 = MaterialBrush.Create(Colors.c_Blue200);
//    public static readonly MaterialBrush Blue_300 = MaterialBrush.Create(Colors.c_Blue300);
//    public static readonly MaterialBrush Blue_400 = MaterialBrush.Create(Colors.c_Blue400);
//    public static readonly MaterialBrush Blue_500 = MaterialBrush.Create(Colors.c_Blue500);
//    public static readonly MaterialBrush Blue_600 = MaterialBrush.Create(Colors.c_Blue600);
//    public static readonly MaterialBrush Blue_700 = MaterialBrush.Create(Colors.c_Blue700);
//    public static readonly MaterialBrush Blue_800 = MaterialBrush.Create(Colors.c_Blue800);
//    public static readonly MaterialBrush Blue_900 = MaterialBrush.Create(Colors.c_Blue900);
//    public static readonly MaterialBrush Blue_A100 = MaterialBrush.Create(Colors.c_BlueA100);
//    public static readonly MaterialBrush Blue_A200 = MaterialBrush.Create(Colors.c_BlueA200);
//    public static readonly MaterialBrush Blue_A400 = MaterialBrush.Create(Colors.c_BlueA400);
//    public static readonly MaterialBrush Blue_A700 = MaterialBrush.Create(Colors.c_BlueA700);

//    public static readonly MaterialBrush LightBlue_050 = MaterialBrush.Create(Colors.c_LightBlue050);
//    public static readonly MaterialBrush LightBlue_100 = MaterialBrush.Create(Colors.c_LightBlue100);
//    public static readonly MaterialBrush LightBlue_200 = MaterialBrush.Create(Colors.c_LightBlue200);
//    public static readonly MaterialBrush LightBlue_300 = MaterialBrush.Create(Colors.c_LightBlue300);
//    public static readonly MaterialBrush LightBlue_400 = MaterialBrush.Create(Colors.c_LightBlue400);
//    public static readonly MaterialBrush LightBlue_500 = MaterialBrush.Create(Colors.c_LightBlue500);
//    public static readonly MaterialBrush LightBlue_600 = MaterialBrush.Create(Colors.c_LightBlue600);
//    public static readonly MaterialBrush LightBlue_700 = MaterialBrush.Create(Colors.c_LightBlue700);
//    public static readonly MaterialBrush LightBlue_800 = MaterialBrush.Create(Colors.c_LightBlue800);
//    public static readonly MaterialBrush LightBlue_900 = MaterialBrush.Create(Colors.c_LightBlue900);
//    public static readonly MaterialBrush LightBlue_A100 = MaterialBrush.Create(Colors.c_LightBlueA100);
//    public static readonly MaterialBrush LightBlue_A200 = MaterialBrush.Create(Colors.c_LightBlueA200);
//    public static readonly MaterialBrush LightBlue_A400 = MaterialBrush.Create(Colors.c_LightBlueA400);
//    public static readonly MaterialBrush LightBlue_A700 = MaterialBrush.Create(Colors.c_LightBlueA700);

//    public static readonly MaterialBrush Cyan_050 = MaterialBrush.Create(Colors.c_Cyan050);
//    public static readonly MaterialBrush Cyan_100 = MaterialBrush.Create(Colors.c_Cyan100);
//    public static readonly MaterialBrush Cyan_200 = MaterialBrush.Create(Colors.c_Cyan200);
//    public static readonly MaterialBrush Cyan_300 = MaterialBrush.Create(Colors.c_Cyan300);
//    public static readonly MaterialBrush Cyan_400 = MaterialBrush.Create(Colors.c_Cyan400);
//    public static readonly MaterialBrush Cyan_500 = MaterialBrush.Create(Colors.c_Cyan500);
//    public static readonly MaterialBrush Cyan_600 = MaterialBrush.Create(Colors.c_Cyan600);
//    public static readonly MaterialBrush Cyan_700 = MaterialBrush.Create(Colors.c_Cyan700);
//    public static readonly MaterialBrush Cyan_800 = MaterialBrush.Create(Colors.c_Cyan800);
//    public static readonly MaterialBrush Cyan_900 = MaterialBrush.Create(Colors.c_Cyan900);
//    public static readonly MaterialBrush Cyan_A100 = MaterialBrush.Create(Colors.c_CyanA100);
//    public static readonly MaterialBrush Cyan_A200 = MaterialBrush.Create(Colors.c_CyanA200);
//    public static readonly MaterialBrush Cyan_A400 = MaterialBrush.Create(Colors.c_CyanA400);
//    public static readonly MaterialBrush Cyan_A700 = MaterialBrush.Create(Colors.c_CyanA700);

//    public static readonly MaterialBrush Teal_050 = MaterialBrush.Create(Colors.c_Teal050);
//    public static readonly MaterialBrush Teal_100 = MaterialBrush.Create(Colors.c_Teal100);
//    public static readonly MaterialBrush Teal_200 = MaterialBrush.Create(Colors.c_Teal200);
//    public static readonly MaterialBrush Teal_300 = MaterialBrush.Create(Colors.c_Teal300);
//    public static readonly MaterialBrush Teal_400 = MaterialBrush.Create(Colors.c_Teal400);
//    public static readonly MaterialBrush Teal_500 = MaterialBrush.Create(Colors.c_Teal500);
//    public static readonly MaterialBrush Teal_600 = MaterialBrush.Create(Colors.c_Teal600);
//    public static readonly MaterialBrush Teal_700 = MaterialBrush.Create(Colors.c_Teal700);
//    public static readonly MaterialBrush Teal_800 = MaterialBrush.Create(Colors.c_Teal800);
//    public static readonly MaterialBrush Teal_900 = MaterialBrush.Create(Colors.c_Teal900);
//    public static readonly MaterialBrush Teal_A100 = MaterialBrush.Create(Colors.c_TealA100);
//    public static readonly MaterialBrush Teal_A200 = MaterialBrush.Create(Colors.c_TealA200);
//    public static readonly MaterialBrush Teal_A400 = MaterialBrush.Create(Colors.c_TealA400);
//    public static readonly MaterialBrush Teal_A700 = MaterialBrush.Create(Colors.c_TealA700);

//    public static readonly MaterialBrush Green_050 = MaterialBrush.Create(Colors.c_Green050);
//    public static readonly MaterialBrush Green_100 = MaterialBrush.Create(Colors.c_Green100);
//    public static readonly MaterialBrush Green_200 = MaterialBrush.Create(Colors.c_Green200);
//    public static readonly MaterialBrush Green_300 = MaterialBrush.Create(Colors.c_Green300);
//    public static readonly MaterialBrush Green_400 = MaterialBrush.Create(Colors.c_Green400);
//    public static readonly MaterialBrush Green_500 = MaterialBrush.Create(Colors.c_Green500);
//    public static readonly MaterialBrush Green_600 = MaterialBrush.Create(Colors.c_Green600);
//    public static readonly MaterialBrush Green_700 = MaterialBrush.Create(Colors.c_Green700);
//    public static readonly MaterialBrush Green_800 = MaterialBrush.Create(Colors.c_Green800);
//    public static readonly MaterialBrush Green_900 = MaterialBrush.Create(Colors.c_Green900);
//    public static readonly MaterialBrush Green_A100 = MaterialBrush.Create(Colors.c_GreenA100);
//    public static readonly MaterialBrush Green_A200 = MaterialBrush.Create(Colors.c_GreenA200);
//    public static readonly MaterialBrush Green_A400 = MaterialBrush.Create(Colors.c_GreenA400);
//    public static readonly MaterialBrush Green_A700 = MaterialBrush.Create(Colors.c_GreenA700);

//    public static readonly MaterialBrush LightGreen_050 = MaterialBrush.Create(Colors.c_LightGreen050);
//    public static readonly MaterialBrush LightGreen_100 = MaterialBrush.Create(Colors.c_LightGreen100);
//    public static readonly MaterialBrush LightGreen_200 = MaterialBrush.Create(Colors.c_LightGreen200);
//    public static readonly MaterialBrush LightGreen_300 = MaterialBrush.Create(Colors.c_LightGreen300);
//    public static readonly MaterialBrush LightGreen_400 = MaterialBrush.Create(Colors.c_LightGreen400);
//    public static readonly MaterialBrush LightGreen_500 = MaterialBrush.Create(Colors.c_LightGreen500);
//    public static readonly MaterialBrush LightGreen_600 = MaterialBrush.Create(Colors.c_LightGreen600);
//    public static readonly MaterialBrush LightGreen_700 = MaterialBrush.Create(Colors.c_LightGreen700);
//    public static readonly MaterialBrush LightGreen_800 = MaterialBrush.Create(Colors.c_LightGreen800);
//    public static readonly MaterialBrush LightGreen_900 = MaterialBrush.Create(Colors.c_LightGreen900);
//    public static readonly MaterialBrush LightGreen_A100 = MaterialBrush.Create(Colors.c_LightGreenA100);
//    public static readonly MaterialBrush LightGreen_A200 = MaterialBrush.Create(Colors.c_LightGreenA200);
//    public static readonly MaterialBrush LightGreen_A400 = MaterialBrush.Create(Colors.c_LightGreenA400);
//    public static readonly MaterialBrush LightGreen_A700 = MaterialBrush.Create(Colors.c_LightGreenA700);

//    public static readonly MaterialBrush Lime_050 = MaterialBrush.Create(Colors.c_Lime050);
//    public static readonly MaterialBrush Lime_100 = MaterialBrush.Create(Colors.c_Lime100);
//    public static readonly MaterialBrush Lime_200 = MaterialBrush.Create(Colors.c_Lime200);
//    public static readonly MaterialBrush Lime_300 = MaterialBrush.Create(Colors.c_Lime300);
//    public static readonly MaterialBrush Lime_400 = MaterialBrush.Create(Colors.c_Lime400);
//    public static readonly MaterialBrush Lime_500 = MaterialBrush.Create(Colors.c_Lime500);
//    public static readonly MaterialBrush Lime_600 = MaterialBrush.Create(Colors.c_Lime600);
//    public static readonly MaterialBrush Lime_700 = MaterialBrush.Create(Colors.c_Lime700);
//    public static readonly MaterialBrush Lime_800 = MaterialBrush.Create(Colors.c_Lime800);
//    public static readonly MaterialBrush Lime_900 = MaterialBrush.Create(Colors.c_Lime900);
//    public static readonly MaterialBrush Lime_A100 = MaterialBrush.Create(Colors.c_LimeA100);
//    public static readonly MaterialBrush Lime_A200 = MaterialBrush.Create(Colors.c_LimeA200);
//    public static readonly MaterialBrush Lime_A400 = MaterialBrush.Create(Colors.c_LimeA400);
//    public static readonly MaterialBrush Lime_A700 = MaterialBrush.Create(Colors.c_LimeA700);

//    public static readonly MaterialBrush Yellow_050 = MaterialBrush.Create(Colors.c_Yellow050);
//    public static readonly MaterialBrush Yellow_100 = MaterialBrush.Create(Colors.c_Yellow100);
//    public static readonly MaterialBrush Yellow_200 = MaterialBrush.Create(Colors.c_Yellow200);
//    public static readonly MaterialBrush Yellow_300 = MaterialBrush.Create(Colors.c_Yellow300);
//    public static readonly MaterialBrush Yellow_400 = MaterialBrush.Create(Colors.c_Yellow400);
//    public static readonly MaterialBrush Yellow_500 = MaterialBrush.Create(Colors.c_Yellow500);
//    public static readonly MaterialBrush Yellow_600 = MaterialBrush.Create(Colors.c_Yellow600);
//    public static readonly MaterialBrush Yellow_700 = MaterialBrush.Create(Colors.c_Yellow700);
//    public static readonly MaterialBrush Yellow_800 = MaterialBrush.Create(Colors.c_Yellow800);
//    public static readonly MaterialBrush Yellow_900 = MaterialBrush.Create(Colors.c_Yellow900);
//    public static readonly MaterialBrush Yellow_A100 = MaterialBrush.Create(Colors.c_YellowA100);
//    public static readonly MaterialBrush Yellow_A200 = MaterialBrush.Create(Colors.c_YellowA200);
//    public static readonly MaterialBrush Yellow_A400 = MaterialBrush.Create(Colors.c_YellowA400);
//    public static readonly MaterialBrush Yellow_A700 = MaterialBrush.Create(Colors.c_YellowA700);

//    public static readonly MaterialBrush Amber_050 = MaterialBrush.Create(Colors.c_Amber050);
//    public static readonly MaterialBrush Amber_100 = MaterialBrush.Create(Colors.c_Amber100);
//    public static readonly MaterialBrush Amber_200 = MaterialBrush.Create(Colors.c_Amber200);
//    public static readonly MaterialBrush Amber_300 = MaterialBrush.Create(Colors.c_Amber300);
//    public static readonly MaterialBrush Amber_400 = MaterialBrush.Create(Colors.c_Amber400);
//    public static readonly MaterialBrush Amber_500 = MaterialBrush.Create(Colors.c_Amber500);
//    public static readonly MaterialBrush Amber_600 = MaterialBrush.Create(Colors.c_Amber600);
//    public static readonly MaterialBrush Amber_700 = MaterialBrush.Create(Colors.c_Amber700);
//    public static readonly MaterialBrush Amber_800 = MaterialBrush.Create(Colors.c_Amber800);
//    public static readonly MaterialBrush Amber_900 = MaterialBrush.Create(Colors.c_Amber900);
//    public static readonly MaterialBrush Amber_A100 = MaterialBrush.Create(Colors.c_AmberA100);
//    public static readonly MaterialBrush Amber_A200 = MaterialBrush.Create(Colors.c_AmberA200);
//    public static readonly MaterialBrush Amber_A400 = MaterialBrush.Create(Colors.c_AmberA400);
//    public static readonly MaterialBrush Amber_A700 = MaterialBrush.Create(Colors.c_AmberA700);

//    public static readonly MaterialBrush Orange_050 = MaterialBrush.Create(Colors.c_Orange050);
//    public static readonly MaterialBrush Orange_100 = MaterialBrush.Create(Colors.c_Orange100);
//    public static readonly MaterialBrush Orange_200 = MaterialBrush.Create(Colors.c_Orange200);
//    public static readonly MaterialBrush Orange_300 = MaterialBrush.Create(Colors.c_Orange300);
//    public static readonly MaterialBrush Orange_400 = MaterialBrush.Create(Colors.c_Orange400);
//    public static readonly MaterialBrush Orange_500 = MaterialBrush.Create(Colors.c_Orange500);
//    public static readonly MaterialBrush Orange_600 = MaterialBrush.Create(Colors.c_Orange600);
//    public static readonly MaterialBrush Orange_700 = MaterialBrush.Create(Colors.c_Orange700);
//    public static readonly MaterialBrush Orange_800 = MaterialBrush.Create(Colors.c_Orange800);
//    public static readonly MaterialBrush Orange_900 = MaterialBrush.Create(Colors.c_Orange900);
//    public static readonly MaterialBrush Orange_A100 = MaterialBrush.Create(Colors.c_OrangeA100);
//    public static readonly MaterialBrush Orange_A200 = MaterialBrush.Create(Colors.c_OrangeA200);
//    public static readonly MaterialBrush Orange_A400 = MaterialBrush.Create(Colors.c_OrangeA400);
//    public static readonly MaterialBrush Orange_A700 = MaterialBrush.Create(Colors.c_OrangeA700);

//    public static readonly MaterialBrush DeepOrange_050 = MaterialBrush.Create(Colors.c_DeepOrange050);
//    public static readonly MaterialBrush DeepOrange_100 = MaterialBrush.Create(Colors.c_DeepOrange100);
//    public static readonly MaterialBrush DeepOrange_200 = MaterialBrush.Create(Colors.c_DeepOrange200);
//    public static readonly MaterialBrush DeepOrange_300 = MaterialBrush.Create(Colors.c_DeepOrange300);
//    public static readonly MaterialBrush DeepOrange_400 = MaterialBrush.Create(Colors.c_DeepOrange400);
//    public static readonly MaterialBrush DeepOrange_500 = MaterialBrush.Create(Colors.c_DeepOrange500);
//    public static readonly MaterialBrush DeepOrange_600 = MaterialBrush.Create(Colors.c_DeepOrange600);
//    public static readonly MaterialBrush DeepOrange_700 = MaterialBrush.Create(Colors.c_DeepOrange700);
//    public static readonly MaterialBrush DeepOrange_800 = MaterialBrush.Create(Colors.c_DeepOrange800);
//    public static readonly MaterialBrush DeepOrange_900 = MaterialBrush.Create(Colors.c_DeepOrange900);
//    public static readonly MaterialBrush DeepOrange_A100 = MaterialBrush.Create(Colors.c_DeepOrangeA100);
//    public static readonly MaterialBrush DeepOrange_A200 = MaterialBrush.Create(Colors.c_DeepOrangeA200);
//    public static readonly MaterialBrush DeepOrange_A400 = MaterialBrush.Create(Colors.c_DeepOrangeA400);
//    public static readonly MaterialBrush DeepOrange_A700 = MaterialBrush.Create(Colors.c_DeepOrangeA700);

//    public static readonly MaterialBrush Brown_050 = MaterialBrush.Create(Colors.c_Brown050);
//    public static readonly MaterialBrush Brown_100 = MaterialBrush.Create(Colors.c_Brown100);
//    public static readonly MaterialBrush Brown_200 = MaterialBrush.Create(Colors.c_Brown200);
//    public static readonly MaterialBrush Brown_300 = MaterialBrush.Create(Colors.c_Brown300);
//    public static readonly MaterialBrush Brown_400 = MaterialBrush.Create(Colors.c_Brown400);
//    public static readonly MaterialBrush Brown_500 = MaterialBrush.Create(Colors.c_Brown500);
//    public static readonly MaterialBrush Brown_600 = MaterialBrush.Create(Colors.c_Brown600);
//    public static readonly MaterialBrush Brown_700 = MaterialBrush.Create(Colors.c_Brown700);
//    public static readonly MaterialBrush Brown_800 = MaterialBrush.Create(Colors.c_Brown800);
//    public static readonly MaterialBrush Brown_900 = MaterialBrush.Create(Colors.c_Brown900);

//    public static readonly MaterialBrush Grey_050 = MaterialBrush.Create(Colors.c_Grey050);
//    public static readonly MaterialBrush Grey_100 = MaterialBrush.Create(Colors.c_Grey100);
//    public static readonly MaterialBrush Grey_200 = MaterialBrush.Create(Colors.c_Grey200);
//    public static readonly MaterialBrush Grey_300 = MaterialBrush.Create(Colors.c_Grey300);
//    public static readonly MaterialBrush Grey_400 = MaterialBrush.Create(Colors.c_Grey400);
//    public static readonly MaterialBrush Grey_500 = MaterialBrush.Create(Colors.c_Grey500);
//    public static readonly MaterialBrush Grey_600 = MaterialBrush.Create(Colors.c_Grey600);
//    public static readonly MaterialBrush Grey_700 = MaterialBrush.Create(Colors.c_Grey700);
//    public static readonly MaterialBrush Grey_800 = MaterialBrush.Create(Colors.c_Grey800);
//    public static readonly MaterialBrush Grey_900 = MaterialBrush.Create(Colors.c_Grey900);

//    public static readonly MaterialBrush BlueGrey_050 = MaterialBrush.Create(Colors.c_BlueGrey050);
//    public static readonly MaterialBrush BlueGrey_100 = MaterialBrush.Create(Colors.c_BlueGrey100);
//    public static readonly MaterialBrush BlueGrey_200 = MaterialBrush.Create(Colors.c_BlueGrey200);
//    public static readonly MaterialBrush BlueGrey_300 = MaterialBrush.Create(Colors.c_BlueGrey300);
//    public static readonly MaterialBrush BlueGrey_400 = MaterialBrush.Create(Colors.c_BlueGrey400);
//    public static readonly MaterialBrush BlueGrey_500 = MaterialBrush.Create(Colors.c_BlueGrey500);
//    public static readonly MaterialBrush BlueGrey_600 = MaterialBrush.Create(Colors.c_BlueGrey600);
//    public static readonly MaterialBrush BlueGrey_700 = MaterialBrush.Create(Colors.c_BlueGrey700);
//    public static readonly MaterialBrush BlueGrey_800 = MaterialBrush.Create(Colors.c_BlueGrey800);
//    public static readonly MaterialBrush BlueGrey_900 = MaterialBrush.Create(Colors.c_BlueGrey900);
//    #endregion

//    public static readonly Swatch Red = Swatch.Create(
//      Red_050,
//      Red_100,
//      Red_200,
//      Red_300,
//      Red_400,
//      Red_500,
//      Red_600,
//      Red_700,
//      Red_800,
//      Red_900,
//      Red_A100,
//      Red_A200,
//      Red_A400,
//      Red_A700);

//    public static readonly Swatch Pink = Swatch.Create(
//      Pink_050,
//      Pink_100,
//      Pink_200,
//      Pink_300,
//      Pink_400,
//      Pink_500,
//      Pink_600,
//      Pink_700,
//      Pink_800,
//      Pink_900,
//      Pink_A100,
//      Pink_A200,
//      Pink_A400,
//      Pink_A700);

//    public static readonly Swatch Purple = Swatch.Create(
//      Purple_050,
//      Purple_100,
//      Purple_200,
//      Purple_300,
//      Purple_400,
//      Purple_500,
//      Purple_600,
//      Purple_700,
//      Purple_800,
//      Purple_900,
//      Purple_A100,
//      Purple_A200,
//      Purple_A400,
//      Purple_A700);

//    public static readonly Swatch DeepPurple = Swatch.Create(
//      DeepPurple_050,
//      DeepPurple_100,
//      DeepPurple_200,
//      DeepPurple_300,
//      DeepPurple_400,
//      DeepPurple_500,
//      DeepPurple_600,
//      DeepPurple_700,
//      DeepPurple_800,
//      DeepPurple_900,
//      DeepPurple_A100,
//      DeepPurple_A200,
//      DeepPurple_A400,
//      DeepPurple_A700);

//    public static readonly Swatch Indigo = Swatch.Create(
//      Indigo_050,
//      Indigo_100,
//      Indigo_200,
//      Indigo_300,
//      Indigo_400,
//      Indigo_500,
//      Indigo_600,
//      Indigo_700,
//      Indigo_800,
//      Indigo_900,
//      Indigo_A100,
//      Indigo_A200,
//      Indigo_A400,
//      Indigo_A700);

//    public static readonly Swatch Blue = Swatch.Create(
//      Blue_050,
//      Blue_100,
//      Blue_200,
//      Blue_300,
//      Blue_400,
//      Blue_500,
//      Blue_600,
//      Blue_700,
//      Blue_800,
//      Blue_900,
//      Blue_A100,
//      Blue_A200,
//      Blue_A400,
//      Blue_A700);

//    public static readonly Swatch LightBlue = Swatch.Create(
//      LightBlue_050,
//      LightBlue_100,
//      LightBlue_200,
//      LightBlue_300,
//      LightBlue_400,
//      LightBlue_500,
//      LightBlue_600,
//      LightBlue_700,
//      LightBlue_800,
//      LightBlue_900,
//      LightBlue_A100,
//      LightBlue_A200,
//      LightBlue_A400,
//      LightBlue_A700);

//    public static readonly Swatch Cyan = Swatch.Create(
//      Cyan_050,
//      Cyan_100,
//      Cyan_200,
//      Cyan_300,
//      Cyan_400,
//      Cyan_500,
//      Cyan_600,
//      Cyan_700,
//      Cyan_800,
//      Cyan_900,
//      Cyan_A100,
//      Cyan_A200,
//      Cyan_A400,
//      Cyan_A700);

//    public static readonly Swatch Teal = Swatch.Create(
//      Teal_050,
//      Teal_100,
//      Teal_200,
//      Teal_300,
//      Teal_400,
//      Teal_500,
//      Teal_600,
//      Teal_700,
//      Teal_800,
//      Teal_900,
//      Teal_A100,
//      Teal_A200,
//      Teal_A400,
//      Teal_A700);

//    public static readonly Swatch Green = Swatch.Create(
//      Green_050,
//      Green_100,
//      Green_200,
//      Green_300,
//      Green_400,
//      Green_500,
//      Green_600,
//      Green_700,
//      Green_800,
//      Green_900,
//      Green_A100,
//      Green_A200,
//      Green_A400,
//      Green_A700);

//    public static readonly Swatch LightGreen = Swatch.Create(
//      LightGreen_050,
//      LightGreen_100,
//      LightGreen_200,
//      LightGreen_300,
//      LightGreen_400,
//      LightGreen_500,
//      LightGreen_600,
//      LightGreen_700,
//      LightGreen_800,
//      LightGreen_900,
//      LightGreen_A100,
//      LightGreen_A200,
//      LightGreen_A400,
//      LightGreen_A700);

//    public static readonly Swatch Lime = Swatch.Create(
//      Lime_050,
//      Lime_100,
//      Lime_200,
//      Lime_300,
//      Lime_400,
//      Lime_500,
//      Lime_600,
//      Lime_700,
//      Lime_800,
//      Lime_900,
//      Lime_A100,
//      Lime_A200,
//      Lime_A400,
//      Lime_A700);

//    public static readonly Swatch Yellow = Swatch.Create(
//      Yellow_050,
//      Yellow_100,
//      Yellow_200,
//      Yellow_300,
//      Yellow_400,
//      Yellow_500,
//      Yellow_600,
//      Yellow_700,
//      Yellow_800,
//      Yellow_900,
//      Yellow_A100,
//      Yellow_A200,
//      Yellow_A400,
//      Yellow_A700);

//    public static readonly Swatch Amber = Swatch.Create(
//      Amber_050,
//      Amber_100,
//      Amber_200,
//      Amber_300,
//      Amber_400,
//      Amber_500,
//      Amber_600,
//      Amber_700,
//      Amber_800,
//      Amber_900,
//      Amber_A100,
//      Amber_A200,
//      Amber_A400,
//      Amber_A700);

//    public static readonly Swatch Orange = Swatch.Create(
//      Orange_050,
//      Orange_100,
//      Orange_200,
//      Orange_300,
//      Orange_400,
//      Orange_500,
//      Orange_600,
//      Orange_700,
//      Orange_800,
//      Orange_900,
//      Orange_A100,
//      Orange_A200,
//      Orange_A400,
//      Orange_A700);

//    public static readonly Swatch DeepOrange = Swatch.Create(
//      DeepOrange_050,
//      DeepOrange_100,
//      DeepOrange_200,
//      DeepOrange_300,
//      DeepOrange_400,
//      DeepOrange_500,
//      DeepOrange_600,
//      DeepOrange_700,
//      DeepOrange_800,
//      DeepOrange_900,
//      DeepOrange_A100,
//      DeepOrange_A200,
//      DeepOrange_A400,
//      DeepOrange_A700);

//    public static readonly Swatch Brown = Swatch.Create(
//      Brown_050,
//      Brown_100,
//      Brown_200,
//      Brown_300,
//      Brown_400,
//      Brown_500,
//      Brown_600,
//      Brown_700,
//      Brown_800,
//      Brown_900);

//    public static readonly Swatch Grey = Swatch.Create(
//      Grey_050,
//      Grey_100,
//      Grey_200,
//      Grey_300,
//      Grey_400,
//      Grey_500,
//      Grey_600,
//      Grey_700,
//      Grey_800,
//      Grey_900);

//    public static readonly Swatch BlueGrey = Swatch.Create(
//      BlueGrey_050,
//      BlueGrey_100,
//      BlueGrey_200,
//      BlueGrey_300,
//      BlueGrey_400,
//      BlueGrey_500,
//      BlueGrey_600,
//      BlueGrey_700,
//      BlueGrey_800,
//      BlueGrey_900);


//    public static readonly Palette Palette = new Palette
//    {
//      Red,
//      Pink,
//      Purple,
//      DeepPurple,
//      Indigo,
//      Blue,
//      LightBlue,
//      Cyan,
//      Teal,
//      Green,
//      LightGreen,
//      Lime,
//      Yellow,
//      Amber,
//      Orange,
//      DeepOrange,
//      Brown,
//      Grey,
//      BlueGrey
//    };

//    static PaletteMock()
//    {

//    }

    

    


//  }
//}
