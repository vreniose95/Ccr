﻿namespace Ccr.PresentationCore.Controls
{
	//public class MobileDeviceInfo
	//{
	//	public MobileDeviceInfo(
	//		string name,
	//		MobileDevicePlatform mobileDevicePlatform,
	//		string softwareVersion,
	//		int portraitWidth,
	//		int landscapeHeight,
	//		string releaseDate)
	//	{
			
	//	}
	//}
	//public enum MobileDevicePlatform
	//{
	//	Android
	//}
	//public class MobileViewport : ValueEnum<MobileDeviceInfo>
	//{
	//	public static MobileDeviceInfo AcerIconiaTabA1810 =
	//		new MobileDeviceInfo(
	//			"Iconia Tab A1-810", MobileDevicePlatform.Android, "4.2.2", 768, 1024, "2013-05");


	//	public static MobileDeviceInfo AcerIconiaTabA100 =
	//		new MobileDeviceInfo(
	//			"Acer Iconia Tab A100", MobileDevicePlatform.Android, "4.0.3", 800, 1280, "2011-04");
		
	//		AcerIconiaTabA101 Acer Iconia Tab A101  Android	3.2.1	600	1024	2011-05
	//	AcerIconiaTabA200  Acer Iconia Tab A200  Android	4.0.3	800	1280	2012-01
	//	AcerIconiaTabA500  Acer Iconia Tab A500  Android	4.0.3	648	1280	2011-04
	//	AcerIconiaTabA501  Acer Iconia Tab A501  Android	3.2	800	1280	2011-04
	//	AcerLiquidE2  Acer Liquid E2  Android	4.2.1	360	640	2013-05
	//	AinolNovo7Elf2	Ainol Novo 7 Elf 2	Android	4.0.3	496	1024	2012-06
	//	AlcatelVodafoneSmartMini875	Alcatel (Vodafone) Smart Mini 875	Android	4.1.1	320	480	2013-07
		
	//	Alcatel One Touch 903	Alcatel One Touch 903	Android	2.3.6	320	427	2012-08
	//	Alcatel One Touch Idol X  Alcatel One Touch Idol X  Android	4.2.2	480	800	2013-07
	//	Alcatel One Touch T10 Alcatel One Touch T10 Android	4.0.3	480	800	2013-03
	//	Amicroe 7 TouchTAB II Amicroe 7 TouchTAB II Android	4.0.4	480	800	2013-01
	//	Amicroe 9.7 TouchTAB IV Amicroe 9.7 TouchTAB IV Android	4.1.1	768	1024	2013-05
	//	Archos 70b (it2)	Archos 70b (it2)	Android	3.2.1	600	1024	2012-02
	//	Archos 80G9 Archos 80G9 Android	3.2	768	1024	2011-09
	//	Arnova 10b G3 Arnova 10b G3 Android	4.0.3	600	1024	2012-05
	//	Arnova 7 G2 Arnova 7 G2 Android	2.3.1	480	800	2011-09
	//	Arnova 7F G3  Arnova 7F G3  Android	4.0.3	640	1067	2012-11
	//	Arnova 8C G3  Arnova 8C G3  Android	4.0.3	800	1067	2012-11
	//	ASUS B1-A71 ASUS B1-A71 Android	4.1.2	600	1024	2013-01
	//	ASUS Fonepad  ASUS Fonepad  Android	4.1.2	601	962	2013-04
	//	ASUS MeMo Pad FHD10/ME302C 10.1	ASUS MeMo Pad FHD10/ME302C 10.1	Android	4.2.2	800	1280	2013-08
	//	ASUS MeMo Pad ME172V  ASUS MeMo Pad ME172V  Android	4.1.1	600	1024	2013-01
	//	ASUS Padfone  ASUS Padfone  Android	4	800	1128	2012-06
	//	ASUS Transformer Pad TF300T ASUS Transformer Pad TF300T Android	4.0.3	800	1280	2012-04
	//	ASUS Transformer TF101  ASUS Transformer TF101  Android	3.1	800	1280	2011-04
	//	ASUS Vivo ASUS Vivo Windows RT	8	768	1366	2012-11
	//	Barnes & Noble Nook HD  Barnes & Noble Nook HD  Android	4.0.4	600	960	2012-11
	//	BAUHN AMID-972XS  BAUHN AMID-972XS  Android	4.0.3	768	1024	2012-09
	//	BAUHN AMID-9743G  BAUHN AMID-9743G  Android	4.1.2	768	1024	2013-02
	//	BAUHN ASP-5000H BAUHN ASP-5000H Android	4.2	360	640	2013-09
	//	BlackBerry 9520	BlackBerry 9520	BlackBerry OS	5	345	691	2009-11
	//	BlackBerry Bold 9000	BlackBerry Bold 9000	BlackBerry OS	4.0.0.223	480	-	2008-08
	//	BlackBerry Bold 9780	BlackBerry Bold 9780	BlackBerry OS	6.0.0.110	480	-	2010-11
	//	BlackBerry Bold 9790	BlackBerry Bold 9790	BlackBerry OS	7.0.0.528	320	-	2011-12
	//	BlackBerry Bold 9900	BlackBerry Bold 9900	BlackBerry OS	7.1.0.342	356	-	2011-08
	//	BlackBerry Curve 9300	BlackBerry Curve 9300	BlackBerry OS	6.0.0.448	320	-	2010-08
	//	BlackBerry Curve 9300	BlackBerry Curve 9300	BlackBerry OS	5.0.0.716	311	-	2010-08
	//	BlackBerry Curve 9320	BlackBerry Curve 9320	BlackBerry OS	7.1.0.569	320	-	2010-05
	//	BlackBerry Curve 9360	BlackBerry Curve 9360	BlackBerry OS	7.0.0.530	320	-	2011-08
	//	BlackBerry Curve 9380	BlackBerry Curve 9380	BlackBerry OS	7.0.0.513	320	406	2011-12
	//	BlackBerry PlayBook BlackBerry PlayBook Blackberry Tablet OS	2.1.0	600	1024	2011-04
	//	BlackBerry Q10  BlackBerry Q10  BlackBerry OS	10.1.0.1910	346	-	2013-04
	//	BlackBerry Torch 9800	BlackBerry Torch 9800	BlackBerry OS	6.0.0.353	360	480	2010-08
	//	BlackBerry Torch 9810	BlackBerry Torch 9810	BlackBerry OS	7.0.0.296	320	-	2011-08
	//	BlackBerry Torch 9860	BlackBerry Torch 9860	BlackBerry OS	7.0.0.579	320	505	2011-09
	//	BlackBerry Z10  BlackBerry Z10  BlackBerry OS	10.0.10.690	342	570	2013-02
	//	Dell Venue 8	Dell Venue 8	Windows 8	8.1	800	1280	Oct-13
	//	Galaxy Nexus  Galaxy Nexus  Android	4.1.1	360	598	2011-11
	//	HP Slate 21	HP Slate 21	Android	4.2.2	1920	NA	2013-10
	//	HP Slate 7 2800	HP Slate 7 2800	Android	4.1.1	600	1024	2013-06
	//	HP Touchpad HP Touchpad Android	4.0.3	768	1024	2011-07
	//	HP Touchpad HP Touchpad webOS	3	768	1024	2011-07
	//	HP Veer HP Veer WebOS	2.1.1	320	545	2011-06
	//	HTC 7 Mozart  HTC 7 Mozart  WP7	7.5	320	480	2010-10
	//	HTC 7 Trophy  HTC 7 Trophy  WP7	7.5	320	480	2010-10
	//	HTC A620b HTC A620b WP8	8	320	480	2013-01
	//	HTC Desire  HTC Desire  Android	2.3.3	320	533	2010-03
	//	HTC Desire 700	HTC Desire 700	Android	4.1.2	360	640	2014-01
	//	HTC Desire C  HTC Desire C  Android	4.0.3	320	480	2012-06
	//	HTC Desire HD HTC Desire HD Android	2.3.5	320	533	2010-10
	//	HTC Desire S  HTC Desire S  Android	4.0.4	320	533	2011-03
	//	HTC Desire X  HTC Desire X  Android	4.1.1	320	533	2012-10
	//	HTC Desire Z (Vision)	HTC Desire Z (Vision)	Android	2.2	480	800	2010-11
	//	HTC Droid Eris  HTC Droid Eris  Android	2.1	320	480	2009-11
	//	HTC Evo 3D	HTC Evo 3D	Android	4.0.3	540	960	2011-07
	//	HTC Incredible 2	HTC Incredible 2	Android	2.3.4	320	533	2011-04
	//	HTC Legend  HTC Legend  Android	2.2	320	480	2010-03
	//	HTC MyTouch Slide 4G  HTC MyTouch Slide 4G  Android	2.3.4	320	533	2011-07
	//	HTC One HTC One Android	4.1.2	360	640	2013-03
	//	HTC One Mini  HTC One Mini  Android	4.2.2	360	640	2013-07
	//	HTC One S HTC One S Android	4.0.3	360	640	2012-04
	//	HTC One SV  HTC One SV  Android	4.0.4	320	533	2012-12
	//	HTC One V HTC One V Android	4.0.3	320	533	2012-04
	//	HTC One X HTC One X Android	4.2.2	360	640	2012-05
	//	HTC One X+	HTC One X+	Android	4.3	360	640	2012-11
	//	HTC One XL  HTC One XL  Android	4.0.3	360	640	2012-05
	//	HTC Rio 8S  HTC Rio 8S  WP8	8	320	480	2012-12
	//	HTC Sensation XL  HTC Sensation XL  Android	4.0.3	360	640	2011-11
	//	HTC Titan II/4G HTC Titan II/4G WP7	7.5	320	480	2012-04
	//	HTC Velocity 4G HTC Velocity 4G Android	4.0.3	360	640	2012-11
	//	HTC Wildfire A3333  HTC Wildfire A3333  Android	2.2.1	267	356	2010-05
	//	HTC Wildfire S  HTC Wildfire S  Android	2.3.3	320	480	2011-05
	//	HTC Windows Phone 8S  HTC Windows Phone 8S  WP8	8	320	480	2012-11
	//	HTC Windows Phone 8X (C625b)	HTC Windows Phone 8X (C625b)	WP8	8	320	480	2012-11
	//	Huawei Ascend G510  Huawei Ascend G510  Android	4.1.1	320	569	2013-04
	//	Huawei Ascend Mate  Huawei Ascend Mate  Android	4.1.1	480	813	2013-03
	//	Huawei U8650 Sonic  Huawei U8650 Sonic  Android	2.3.3	320	480	2011-06
	//	Huawei U8860  Huawei U8860  Android	4.0.3	320	544	2011-12
	//	Huawei Y300-0151	Huawei Y300-0151	Android	4.1.1	320	533	2013-03
	//	iPad  iPad  iOS	5.0.1	768	1024	2010-03
	//	iPad 2	iPad 2	iOS	5.0.1	768	1024	2011-03
	//	iPad 3	iPad 3	iOS	5.1.1	768	1024	2012-03
	//	iPad Air  iPad Air  iOS	7.0.3	768	1024	2013-10
	//	iPad Mini iPad Mini iOS	6.0.1	768	1024	2012-11
	//	iPhone  iPhone  iOS	3.1.3	320	480	2007-06
	//	iPhone 3G iPhone 3G iOS	4.2.1	320	480	2008-07
	//	iPhone 3GS  iPhone 3GS  iOS	6.0a2	320	480	2009-06
	//	iPhone 4	iPhone 4	iOS	5.1.1	320	480	2010-06
	//	iPhone 4S iPhone 4S iOS	4.3.5	320	480	2011-10
	//	iPhone 5	iPhone 5	iOS	6	320	568	2012-09
	//	iPhone 5c iPhone 5c iOS	7	320	568	2013-09
	//	iPhone 5s iPhone 5s iOS	7	320	568	2013-09
	//	iPhone 6	iPhone 6	iOS	8	375	667	2014-09
	//	iPhone 6 Plus iPhone 6 Plus iOS	8	414	736	2014-09
	//	iPod Touch 4th Gen  iPod Touch 4th Gen  iOS	5.0.1	320	480	2010-09
	//	iPod Touch 5th Gen  iPod Touch 5th Gen  iOS	6	320	568	2012-10
	//	Kindle 3	Kindle 3	Kindle	3.3	600	-	2010-08
	//	Kindle Fire 2	Kindle Fire 2	Android	4.0.3	600	963	2011-11
	//	Kindle Fire HD  Kindle Fire HD  Android	4	533	801	2012-09
	//	Kindle Fire HD 8.9	Kindle Fire HD 8.9	Android	4.0.3	800	1220	2012-10
	//	Kindle Paperwhite Kindle Paperwhite Kindle	5	758	-	2012-10
	//	Kobo eReader Touch  Kobo eReader Touch  Android	2.0.0	600	-	2011-06
	//	Kogan 42" Smart 3D LED TV	Kogan 42" Smart 3D LED TV Android	4.1.2	-	1280	2013-07
	//	Lenovo IdeaTab A1000  Lenovo IdeaTab A1000  Android	4.2.2	600	1024	2013-05
	//	Lenovo IdeaTab S6000  Lenovo IdeaTab S6000  Android	4.2.2	800	1280	2013-06
	//	Lenovo Yoga Tablet 10	Lenovo Yoga Tablet 10	Android	4.2.2	800	1280	2013-11
	//	Lenovo Yoga Tablet 8	Lenovo Yoga Tablet 8	Android	4.2.2	602	962	2013-10
	//	LG 55LW6500 TV  LG 55LW6500 TV  Proprietary (TV)	5.00.07	-	1280	2011-03
	//	LG Ally LG Ally Android	2.2.2	320	533	2010-04
	//	LG G2 LG G2 Android	4.2.2	360	598	2013-09
	//	LG Optimus 2x LG Optimus 2x Android	2.3.7	320	533	2011-02
	//	LG Optimus Black P970 LG Optimus Black P970 Android	4.0.4	320	533	2011-05
	//	LG Optimus G E975 LG Optimus G E975 Android	4.1.2	384	640	2012-11
	//	LG Optimus L3 E400  LG Optimus L3 E400  Android	2.3.6	320	427	2012-02
	//	LG Optimus L3 II E425f  LG Optimus L3 II E425f  Android	4.1.2	320	427	2013-04
	//	LG Optimus L7 P700  LG Optimus L7 P700  Android	4.0.3	320	533	2012-05
	//	LG Optimus L9 P760  LG Optimus L9 P760  Android	4.0.4	360	640	2012-11
	//	LG Optimus Pad V900 LG Optimus Pad V900 Android	3.0.1	768	1280	2011-05
	//	LG Viewty KU990 LG Viewty KU990 Proprietary (Java)	1.2	240	400	2008-10
	//	Microsoft Surface Microsoft Surface Windows RT	8	768	1366	2012-11
	//	Microsoft Surface Pro Microsoft Surface Pro Windows 8	8	720	1280	2012-11
	//	Motorola Defy Motorola Defy Android	2.3.4	320	569	2010-10
	//	Motorola Defy Mini  Motorola Defy Mini  Android	2.3.6	320	480	2012-01
	//	Motorola Droid 3	Motorola Droid 3	Android	2.3	360	559	2011-07
	//	Motorola Droid Bionic Motorola Droid Bionic Android	4.1.2	360	640	2011-09
	//	Motorola Droid Razr Motorola Droid Razr Android	2.3.6	360	640	2011-11
	//	Motorola Electrify 2	Motorola Electrify 2	Android	4.1.2	360	598	2012-07
	//	Motorola Fire XT  Motorola Fire XT  Android	2.3.5	320	480	2011-09
	//	Motorola FlipOut  Motorola FlipOut  Android	2.1	320	240	2010-06
	//	Motorola Milestone  Motorola Milestone  Android	2.3.7	320	569	2009-11
	//	Motorola Moto G Motorola Moto G Android	4.3	360	598	2013-11
	//	Motorola RAZR HD 4G Motorola RAZR HD 4G Android	4.0.4	360	598	2012-09
	//	Motorola RAZR M 4G  Motorola RAZR M 4G  Android	4.0.4	360	598	2012-09
	//	Motorola RAZR MAXX  Motorola RAZR MAXX  Android	4	360	640	2012-05
	//	Motorola Xoom Motorola Xoom Android	4.1	800	1280	2011-05
	//	Motorola Xoom 2	Motorola Xoom 2	Android	3.2.2	800	1280	2011-12
	//	Motorola Xoom 2 Media Edition Motorola Xoom 2 Media Edition Android	3.2.2	800	1280	2011-12
	//	Nexus 10	Nexus 10	Android	4.2.2	800	1280	2012-11
	//	Nexus 4	Nexus 4	Android	4.2.1	384	598	2012-11
	//	Nexus 5	Nexus 5	Android	4.4	360	598	2013-10
	//	Nexus 7	Nexus 7	Android	4.1.1	603	966	2012-07
	//	Nexus 7	Nexus 7	Android	4.3	601	962	2012-07
	//	Nexus 7	Nexus 7	Android	4.2.1	600	961	2012-07
	//	Nexus 7 (2013)	Nexus 7 (2013)	Android	4.3	600	960	2013-07
	//	Nexus 7 (LCD Density set to 175PPI)	Nexus 7 (LCD Density set to 175PPI)	Android	4.1.1	731	1170	2012-07
	//	Nexus One Nexus One Android	2.3.7	320	533	2010-01
	//	Nexus S Nexus S Android	4.1.1	320	533	2010-10
	//	Nintendo 3DS  Nintendo 3DS	3DS	4.3.0-10E	416	-	2011-02
	//	Nintendo 3DS XL Nintendo 3DS XL	3DS	1.7455.EU	416	-	2012-07
	//	Nintendo DSi  Nintendo DSi  DSi	507; U; en-GB	256	-	2009-04
	//	Nintendo DSi XL Nintendo DSi XL DSi	1.4.4A	240	-	2010-03
	//	Nintendo Wii  Nintendo Wii  Wii	4.3	800	-	2007-11
	//	Nintendo Wii U  Nintendo Wii U  Wii U	1.0.0.7494	854	-	2012-11
	//	Nokia 2700	Nokia 2700	S40	5th Edition	240	-	2009-07
	//	Nokia 500	Nokia 500	Symbian Belle	360	640	2011-09
	//	Nokia 700 (Opera Mobile)	Nokia 700 (Opera Mobile)	Symbian Belle FP2	240	427	2011-09
	//	Nokia Asha 300	Nokia Asha 300	Proprietary (Nokia)	07.03 29-11-11 RM-781	234	-	2011-11
	//	Nokia Asha 302	Nokia Asha 302	Proprietary (Nokia)	14.53 20-03-12 RM-813	314	-	2012-03
	//	Nokia E61i  Nokia E61i  S60 Symbian 9.1	320	-	2007-04
	//	Nokia E71 Nokia E71 S60 Symbian 9.2	320	-	2007-04
	//	Nokia Lumia 1520	Nokia Lumia 1520	WP8	8	320	480	2013-11
	//	Nokia Lumia 520	Nokia Lumia 520	WP8	8	320	480	2013-04
	//	Nokia Lumia 610	Nokia Lumia 610	WP7	7.5	320	480	2012-04
	//	Nokia Lumia 710	Nokia Lumia 710	WP7	7.5	320	480	2011-12
	//	Nokia Lumia 720	Nokia Lumia 720	WP7	8	320	480	2013-04
	//	Nokia Lumia 800	Nokia Lumia 800	WP7	7.5	320	480	2011-11
	//	Nokia Lumia 820	Nokia Lumia 820	WP8	8	320	480	2012-11
	//	Nokia Lumia 900	Nokia Lumia 900	WP7	7.5	320	480	2012-05
	//	Nokia Lumia 920	Nokia Lumia 920	WP8	8	320	480	2012-11
	//	Nokia Lumia 925	Nokia Lumia 925	WP8	8	320	480	2013-06
	//	Nokia N9  Nokia N9  MeeGo	1.2	320	496	2011-09
	//	Nokia N900  Nokia N900  Maemo	5	480	800	2009-11
	//	Nokia N95 Nokia N95 S60 Symbian 9.2	240	-	2007-03
	//	Palm Pixi Palm Pixi WebOS	1.4.5	320	480	2009-11
	//	Palm Pre  Palm Pre  WebOS	2.2	320	-	2009-10
	//	Panasonic Toughpad FZ-A1  Panasonic Toughpad FZ-A1  Android	4	768	1024	2012-12
	//	PendoPad 10"	PendoPad 10"	Android	4.2.2	600	1024	2013-11
	//	PendoPad 7"	PendoPad 7"	Android	4.2.2	480	800	2013-11
	//	Pioneer Dreambook Pioneer Dreambook Android	4.0.4	768	1024	2010-07
	//	Samsung Ativ S  Samsung Ativ S  WP8	8	320	480	2012-12
	//	Samsung E3210 Samsung E3210 Proprietary (Java)	-	128	-	2011-05
	//	Samsung Galaxy 5/Europa I5500 Samsung Galaxy 5/Europa I5500 Android	2.1-update1	320	427	2010-08
	//	Samsung Galaxy Ace 2 I8160  Samsung Galaxy Ace 2 I8160  Android	2.3.6	320	533	2012-05
	//	Samsung Galaxy Ace Plus S7500 Samsung Galaxy Ace Plus S7500 Android	2.3.6	320	480	2012-02
	//	Samsung Galaxy Ace S5830  Samsung Galaxy Ace S5830  Android	2.3.4	320	480	2011-02
	//	Samsung Galaxy Beam I8530 Samsung Galaxy Beam I8530 Android	2.3.6	320	533	2012-07
	//	Samsung Galaxy Camera GC100 Samsung Galaxy Camera GC100 Android	4.1.2	360	598	2012-11
	//	Samsung Galaxy Mini 2 S6500 Samsung Galaxy Mini 2 S6500 Android	2.3	320	480	2012-03
	//	Samsung Galaxy Mini S5570 Samsung Galaxy Mini S5570 Android	2.3.4	240	320	2011-02
	//	Samsung Galaxy Note 10.1 (2014 Edition) P600  Samsung Galaxy Note 10.1 (2014 Edition) P600  Android	4.3	800	1280	2013-11
	//	Samsung Galaxy Note 10.1 N8010  Samsung Galaxy Note 10.1 N8010  Android	4.0.4	800	1280	2012-08
	//	Samsung Galaxy Note 10.1 N8010 (Multiscreen Enabled)	Samsung Galaxy Note 10.1 N8010 (Multiscreen Enabled)	Android	4.0.4	800	637	2012-08
	//	Samsung Galaxy Note 2 N7100 Samsung Galaxy Note 2 N7100 Android	4.1.1	360	640	2012-09
	//	Samsung Galaxy Note 3 N9005 Samsung Galaxy Note 3 N9005 Android	4.3	360	640	2013-09
	//	Samsung Galaxy Note 8.0 N5100 Samsung Galaxy Note 8.0 N5100 Android	4.1.2	601	962	2013-04
	//	Samsung Galaxy Note 8.0 N5110 Samsung Galaxy Note 8.0 N5110 Android	4.1.2	601	962	2013-04
	//	Samsung Galaxy Note N700  Samsung Galaxy Note N700  Android	2.3.6	400	640	2011-10
	//	Samsung Galaxy S Duos S7562 Samsung Galaxy S Duos S7562 Android	4.0.4	320	533	2012-09
	//	Samsung Galaxy S I9000  Samsung Galaxy S I9000  Android	2.3.6	320	533	2010-06
	//	Samsung Galaxy S WiFi YPG70CW Samsung Galaxy S WiFi YPG70CW Android	2.2	320	533	2011-05
	//	Samsung Galaxy S2 I9100 Samsung Galaxy S2 I9100 Android	2.3.6	320	533	2011-04
	//	Samsung Galaxy S3 I9300 Samsung Galaxy S3 I9300 Android	4.0.4	360	640	2012-05
	//	Samsung Galaxy S3 Mini I8190  Samsung Galaxy S3 Mini I8190  Android	4.1.2	320	533	2012-11
	//	Samsung Galaxy S4 Active I9295  Samsung Galaxy S4 Active I9295  Android	4.2.2	360	640	2013-06
	//	Samsung Galaxy S4 I9500 Samsung Galaxy S4 I9500 Android	4.2.2	360	640	2013-04
	//	Samsung Galaxy S4 I9505 Samsung Galaxy S4 I9505 Android	4.2.2	360	640	2013-04
	//	Samsung Galaxy S4 Mini I9190  Samsung Galaxy S4 Mini I9190  Android	4.2.2	360	640	2013-07
	//	Samsung Galaxy S4 Zoom SM-C105  Samsung Galaxy S4 Zoom SM-C105  Android	4.2.2	360	640	2013-07
	//	Samsung Galaxy Tab 10.1 P7510 Samsung Galaxy Tab 10.1 P7510 Android	3.2	800	1280	2011-07
	//	Samsung Galaxy Tab 2 10.1 P5110 Samsung Galaxy Tab 2 10.1 P5110 Android	4.0.4	800	1280	2012-05
	//	Samsung Galaxy Tab 2 7.0 P3110  Samsung Galaxy Tab 2 7.0 P3110  Android	4.0.3	600	1024	2012-05
	//	Samsung Galaxy Tab 3 10.1 P5210 Samsung Galaxy Tab 3 10.1 P5210 Android	4.2.2	800	1280	2013-07
	//	Samsung Galaxy Tab 3 7.0 T210 Samsung Galaxy Tab 3 7.0 T210 Android	4.1.2	600	1024	2013-07
	//	Samsung Galaxy Tab 3 8.0 T310 Samsung Galaxy Tab 3 8.0 T310 Android	4.2.2	602	962	2013-07
	//	Samsung Galaxy Tab 3 Kids T2105 Samsung Galaxy Tab 3 Kids T2105 Android	4.1.2	600	1024	2013-11
	//	Samsung Galaxy Tab 7.0 Plus P6210 Samsung Galaxy Tab 7.0 Plus P6210 Android	3.2	600	1024	2012-01
	//	Samsung Galaxy Tab 7.7 P6810  Samsung Galaxy Tab 7.7 P6810  Android	3.2	800	1280	2012-01
	//	Samsung Galaxy Tab 8.9 4G P7320 Samsung Galaxy Tab 8.9 4G P7320 Android	3.2	800	1280	2012-02
	//	Samsung Galaxy Tab 8.9 P7310  Samsung Galaxy Tab 8.9 P7310  Android	4.0.4	800	1280	2011-05
	//	Samsung Galaxy Tab P1000  Samsung Galaxy Tab P1000  Android	2.3.3	400	683	2010-10
	//	Samsung Galaxy X Cover 2 S7710  Samsung Galaxy X Cover 2 S7710  Android	4.1.2	320	533	2013-03
	//	Samsung Galaxy Y S5360  Samsung Galaxy Y S5360  Android	2.3.6	320	427	2011-10
	//	Samsung Galaxy Young S6310  Samsung Galaxy Young S6310  Android	4.1.2	320	480	2013-02
	//	Samsung Infuse 4G I997  Samsung Infuse 4G I997  Android	2.3	320	533	2011-05
	//	Samsung Omnia 7 I8700 Samsung Omnia 7 I8700 WP7	7.5	320	480	2010-10
	//	Samsung Omnia W I8350 Samsung Omnia W I8350 WP7	7.5	320	480	2011-10
	//	Samsung Wave S8500  Samsung Wave S8500  Bada	2.0.1	320	534	2010-04
	//	Samsung Wave S8500  Samsung Wave S8500  Bada	1	240	400	2010-04
	//	Scroll Excel  Scroll Excel  Android	2.3.4	480	800	2012-02
	//	Sony BRAVIA 40 EX520  Sony BRAVIA 40 EX520  Proprietary (TV)	PKG4.012GAA-0104	-	1920	2011-01
	//	Sony Ericcson Xperia Play Sony Ericcson Xperia Play Android	2.3.4	425	974	2011-03
	//	Sony Ericsson Elm Sony Ericsson Elm Proprietary (Java)	1231-1917 R7CA061 100619	240	-	2010-03
	//	Sony Ericsson Spiro Sony Ericsson Spiro Proprietary (Java)	-	240	-	2010-08
	//	Sony Ericsson Xperia Arc  Sony Ericsson Xperia Arc  Android	2.3.4	320	569	2011-03
	//	Sony Ericsson Xperia Mini ST15i Sony Ericsson Xperia Mini ST15i Android	2.3.4	320	401	2011-08
	//	Sony Ericsson Xperia Neo  Sony Ericsson Xperia Neo  Android	4.0.4	480	854	2011-03
	//	Sony Ericsson Xperia X10  Sony Ericsson Xperia X10  Android	2.3.3	320	569	2010-03
	//	Sony Ericsson Xperia X8 Sony Ericsson Xperia X8 Android	2.1.1	320	480	2010-09
	//	Sony PlayStation 3	Sony PlayStation 3	PlayStation 3	4.25	-	1824	2006-11
	//	Sony PlayStation Portable Sony PlayStation Portable PlayStation Portable	4.2	-	480	2005-03
	//	Sony PlayStation Vita Sony PlayStation Vita PlayStation Vita	1	-	896	2012-02
	//	Sony Tablet P Sony Tablet P Android	4.0.3	-	1024	2012-09
	//	Sony Tablet S Sony Tablet S Android	4.0.3	800	1280	2011-09
	//	Sony VAIO Tap 20	Sony VAIO Tap 20	Windows 8	8	900	1600	2013-06
	//	Sony Xperia acro S  Sony Xperia acro S  Android	4.0.4	360	640	2012-08
	//	Sony Xperia P Sony Xperia P Android	2.3.7	360	640	2012-05
	//	Sony Xperia S Sony Xperia S Android	2.3.7	360	640	2012-02
	//	Sony Xperia Sola  Sony Xperia Sola  Android	2.3.7	320	569	2012-05
	//	Sony Xperia SP  Sony Xperia SP  Android	4.1.2	360	598	2013-04
	//	Sony Xperia Tablet Z  Sony Xperia Tablet Z  Android	4.1.2	800	1280	2013-05
	//	Sony Xperia Tipo  Sony Xperia Tipo  Android	4.0.4	320	480	2012-08
	//	Sony Xperia U Sony Xperia U Android	2.3.7	320	569	2012-05
	//	Sony Xperia V Sony Xperia V Android	4.1.2	360	598	2012-12
	//	Sony Xperia Z Sony Xperia Z Android	4.1.2	360	598	2013-02
	//	Sony Xperia Z1  Sony Xperia Z1  Android	4.2.2	360	598	2013-09
	//	Telstra T-Hub 2	Telstra T-Hub 2	Android	2.3.7	400	683	2012-07
	//	Tesco Hudl  Tesco Hudl  Android	4.2	600	799	2013-09
	//	Toshiba AT100 Toshiba AT100 Android	4.0.4	800	1280	2011-07
	//	Toshiba AT1S0 Toshiba AT1S0 Android	3.2	602	961	2012-02
	//	Toshiba AT200 Toshiba AT200 Android	3.2.1	800	1280	2012-02
	//	Toshiba AT300 Toshiba AT300 Android	4.0.3	800	1280	2012-06
	//	Toshiba AT330 Toshiba AT330 Android	4.0.3	900	1600	2012-07
	//	Wiko Cink Slim  Wiko Cink Slim  Android	4.1.1	320	533	2012-11
	//	XBOX 360	XBOX 360	XBOX	2	-	1050	2005-11
	//	Xiaomi MI-3	Xiaomi MI-3	Android	4.2.1	360	640	2013-09
	//	Yarvik Xenta Tab 8c Yarvik Xenta Tab 8c Android	4.1.2	768	1024	2013-08
	//	ZTE Open  ZTE Open  FireFox OS	1.0.0B01	320	415	2013-07
	//	ZTE T22 (Telstra Urbane)	ZTE T22 (Telstra Urbane)	Android	4.0.4	320	533	2012-08
	//	ZTE T28 (Telstra Active Touch)	ZTE T28 (Telstra Active Touch)	Android	2.3.5	320	533	2011-05
	//	ZTE T760 (Telstra Smart-Touch 2)	ZTE T760 (Telstra Smart-Touch 2)	Android	2.3.5	320	480	2012-02
	//	ZTE T790 (Telstra Pulse)	ZTE T790 (Telstra Pulse)	Android	4.0.4	320	480	2013-05
	//	ZTE T81 (Telstra Frontier 4G)	ZTE T81 (Telstra Frontier 4G)	Android	4.0.4	320	533	2012-11
	//	ZTE T82 (Telstra Easy Touch 4G)	ZTE T82 (Telstra Easy Touch 4G)	Android	4.0.4	360	598	2012-11
	//	ZTE T83 (Telstra Dave 4G)	ZTE T83 (Telstra Dave 4G)	Android	4.1.2	320	534	2013-10
						

	}

