USE [master]
GO
/****** Object:  Database [FaultsTracking]    Script Date: 10.01.2022 14:10:27 ******/
CREATE DATABASE [FaultsTracking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FaultsTracking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\FaultsTracking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FaultsTracking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\FaultsTracking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FaultsTracking] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FaultsTracking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FaultsTracking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FaultsTracking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FaultsTracking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FaultsTracking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FaultsTracking] SET ARITHABORT OFF 
GO
ALTER DATABASE [FaultsTracking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FaultsTracking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FaultsTracking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FaultsTracking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FaultsTracking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FaultsTracking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FaultsTracking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FaultsTracking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FaultsTracking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FaultsTracking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FaultsTracking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FaultsTracking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FaultsTracking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FaultsTracking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FaultsTracking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FaultsTracking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FaultsTracking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FaultsTracking] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FaultsTracking] SET  MULTI_USER 
GO
ALTER DATABASE [FaultsTracking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FaultsTracking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FaultsTracking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FaultsTracking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FaultsTracking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FaultsTracking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FaultsTracking] SET QUERY_STORE = OFF
GO
USE [FaultsTracking]
GO
/****** Object:  Table [dbo].[T_Ariza]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Ariza](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[perID] [int] NOT NULL,
	[bildirimZamani] [datetime] NOT NULL,
	[Ariza] [nvarchar](150) NOT NULL,
	[islem] [varchar](max) NULL,
	[MudahaleZamani] [datetime] NULL,
	[malzemeID] [int] NULL,
	[teknisyenAta] [nvarchar](150) NOT NULL,
	[durumID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[rapor] [varchar](max) NULL,
	[uzmanAta] [nvarchar](50) NULL,
	[arizaYeri] [nvarchar](150) NULL,
 CONSTRAINT [PK_T_Ariza] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_IsDurum]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_IsDurum](
	[durumID] [int] NOT NULL,
	[Durum] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_T_IsDurum] PRIMARY KEY CLUSTERED 
(
	[durumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Islemler]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Islemler](
	[islemID] [int] IDENTITY(1,1) NOT NULL,
	[islem] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_T_Islemler] PRIMARY KEY CLUSTERED 
(
	[islemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Malzemeler]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Malzemeler](
	[malzemeID] [int] IDENTITY(1,1) NOT NULL,
	[malzemeAd] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_Malzemeler] PRIMARY KEY CLUSTERED 
(
	[malzemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Personeller]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Personeller](
	[perID] [int] IDENTITY(1,1) NOT NULL,
	[perAdSoyad] [nvarchar](50) NOT NULL,
	[perTc] [nvarchar](50) NOT NULL,
	[perTelefon] [nvarchar](50) NOT NULL,
	[perMail] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_T_Personeller] PRIMARY KEY CLUSTERED 
(
	[perID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Yetkiler]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Yetkiler](
	[yetkiID] [int] NOT NULL,
	[Yetki] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_Yetkiler] PRIMARY KEY CLUSTERED 
(
	[yetkiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Yonetim]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Yonetim](
	[yonetimID] [int] IDENTITY(1,1) NOT NULL,
	[AdiSoyadi] [nvarchar](50) NOT NULL,
	[Tc] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](64) NOT NULL,
	[yetkiID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_T_Yonetim] PRIMARY KEY CLUSTERED 
(
	[yonetimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_Ariza] ON 

INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (1, 3, CAST(N'2022-01-07T00:00:00.000' AS DateTime), N'monitor kapandı açılmıyor', NULL, NULL, NULL, N'Mesut Yıldırm
Remzi Savcı
', 4, 1, N'Sorun Çözülmüş', N'12345678911', N'van myo')
INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (2, 3, CAST(N'2022-01-07T00:00:00.000' AS DateTime), N'projeksiyon çalışmıyor', NULL, NULL, NULL, N'Mesut Yıldırm
', 3, 1, N'Kabul Edildi', N'12345678952', N'ilahiyat fakultesi')
INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (3, 1, CAST(N'2022-01-07T00:00:00.000' AS DateTime), N'Wifi çalışmıyor', NULL, NULL, NULL, N'Mesut Yıldırm
Recep Aktaş
', 1, 1, N'Kabul Edildi', N'12345678911', N'ilahiyat fakultesi')
INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (4, 5, CAST(N'2022-01-07T00:00:00.000' AS DateTime), N'internet arızası', NULL, NULL, NULL, N'Nazlı Çetin
Cahit Yüksel
', 3, 0, N'Kabul Edildi', N'12345678952', N'diş fakultesi')
INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (5, 1, CAST(N'2022-01-07T00:00:00.000' AS DateTime), N'Bilgisayar kablosu koptu', NULL, NULL, NULL, N'Mesut Yıldırm
Recep Aktaş
', 1, 1, N'Kabul Edildi', N'12345678911', N'Tıp fakultesi')
INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (6, 4, CAST(N'2022-01-07T00:00:00.000' AS DateTime), N'klavye bozuldu', N'Kalvye değiştirildi', CAST(N'2022-01-07T00:00:00.000' AS DateTime), 2, N'Mesut Yıldırm
', 2, 1, N'Kabul Edildi', N'12345678911', N'Fen ve edebiyat fakultesi')
INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (7, 3, CAST(N'2022-01-10T00:00:00.000' AS DateTime), N'interenet arızası', NULL, NULL, NULL, N'Cahit Yüksel
Esila Polat
', 3, 1, N'Kabul Edildi', N'12345678911', N'van myo')
INSERT [dbo].[T_Ariza] ([ID], [perID], [bildirimZamani], [Ariza], [islem], [MudahaleZamani], [malzemeID], [teknisyenAta], [durumID], [IsActive], [rapor], [uzmanAta], [arizaYeri]) VALUES (8, 1, CAST(N'2022-01-10T00:00:00.000' AS DateTime), N'sdfdskhfodsıgfjdkgldfgjhıferjjggkjdfjkdfjfdkdfgjfnghghfhhghfhgfhgjdfdfvfjdfjdfkp jfgjfjgjfg fgjfjgjfj jfjgjfg fgjfjfjgfg fgjfgnfgfjgfg ', NULL, NULL, NULL, N'Cahit Yüksel
Esila Polat
', 3, 1, N'Kabul Edildi', N'12345678911', N'van myo')
SET IDENTITY_INSERT [dbo].[T_Ariza] OFF
GO
INSERT [dbo].[T_IsDurum] ([durumID], [Durum]) VALUES (1, N'Kabul Edildi')
INSERT [dbo].[T_IsDurum] ([durumID], [Durum]) VALUES (2, N'Tamamlandı')
INSERT [dbo].[T_IsDurum] ([durumID], [Durum]) VALUES (3, N'Bekliyor')
INSERT [dbo].[T_IsDurum] ([durumID], [Durum]) VALUES (4, N'Red Edildi')
GO
SET IDENTITY_INSERT [dbo].[T_Malzemeler] ON 

INSERT [dbo].[T_Malzemeler] ([malzemeID], [malzemeAd]) VALUES (1, N'Mause')
INSERT [dbo].[T_Malzemeler] ([malzemeID], [malzemeAd]) VALUES (2, N'Klavye')
INSERT [dbo].[T_Malzemeler] ([malzemeID], [malzemeAd]) VALUES (3, N'İnternet Kablosu')
SET IDENTITY_INSERT [dbo].[T_Malzemeler] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Personeller] ON 

INSERT [dbo].[T_Personeller] ([perID], [perAdSoyad], [perTc], [perTelefon], [perMail], [IsActive]) VALUES (1, N'Ferit Gülmez', N'12345678978', N'05489656327', N'ferit@gmail.com', 1)
INSERT [dbo].[T_Personeller] ([perID], [perAdSoyad], [perTc], [perTelefon], [perMail], [IsActive]) VALUES (2, N'Murat Çiçek', N'12345678800', N'05468963245', N'murat@gmail.com', 1)
INSERT [dbo].[T_Personeller] ([perID], [perAdSoyad], [perTc], [perTelefon], [perMail], [IsActive]) VALUES (3, N'Kasım Talat', N'12345678801', N'05347851265', N'kasım@gmail.com', 1)
INSERT [dbo].[T_Personeller] ([perID], [perAdSoyad], [perTc], [perTelefon], [perMail], [IsActive]) VALUES (4, N'Adnan Tarlacı', N'12345678806', N'05347859612', N'adnan@gmail.com', 1)
INSERT [dbo].[T_Personeller] ([perID], [perAdSoyad], [perTc], [perTelefon], [perMail], [IsActive]) VALUES (5, N'Muhammed Buğra Çakan', N'12345678804', N'05368957642', N'mbugra@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[T_Personeller] OFF
GO
INSERT [dbo].[T_Yetkiler] ([yetkiID], [Yetki]) VALUES (1, N'Superuser')
INSERT [dbo].[T_Yetkiler] ([yetkiID], [Yetki]) VALUES (2, N'Müdür')
INSERT [dbo].[T_Yetkiler] ([yetkiID], [Yetki]) VALUES (3, N'Uzman')
INSERT [dbo].[T_Yetkiler] ([yetkiID], [Yetki]) VALUES (4, N'Teknisyen')
GO
SET IDENTITY_INSERT [dbo].[T_Yonetim] ON 

INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (1, N'Demhat Demir', N'12345678912', N'demhat@demhat.info', N'05364589865', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (2, N'Ferman Deli', N'12345678910', N'ferman@gmail.com', N'05364589756', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 2, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (3, N'Derin Güven', N'12345678911', N'derin@gmail.com', N'05364587965', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 3, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (4, N'Remzi Savcı', N'12345678999', N'remzi@gmail.com', N'05368967854', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 4, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (5, N'Recep Aktaş', N'12345678998', N'recap@gmail.com', N'05368965632', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 4, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (6, N'Esila Polat', N'12345678997', N'esila@gmail.com', N'05368965421', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 4, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (7, N'Nazlı Çetin', N'12345678995', N'nazli@gmail.com', N'05489653278', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 4, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (8, N'Cahit Yüksel', N'12345678954', N'cahit@gmail.com', N'05487965321', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 4, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (9, N'Mesut Yıldırm', N'12345678948', N'mesut@gmail.com', N'05348657852', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 4, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (10, N'Abdurahman Deveboynu', N'12345678913', N'abdurahman@gmail.com', N'05589635621', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 2, 1)
INSERT [dbo].[T_Yonetim] ([yonetimID], [AdiSoyadi], [Tc], [Email], [Telefon], [Sifre], [yetkiID], [IsActive]) VALUES (11, N'Orhan Özgüçlü', N'12345678952', N'orhan@gmail.com', N'05368965632', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 3, 1)
SET IDENTITY_INSERT [dbo].[T_Yonetim] OFF
GO
ALTER TABLE [dbo].[T_Ariza] ADD  CONSTRAINT [DF_T_Ariza_Durum]  DEFAULT ((1)) FOR [durumID]
GO
ALTER TABLE [dbo].[T_Ariza] ADD  CONSTRAINT [DF_T_Ariza_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[T_Ariza] ADD  CONSTRAINT [DF_T_Ariza_rapor]  DEFAULT ('Kabul Edildi') FOR [rapor]
GO
ALTER TABLE [dbo].[T_Islemler] ADD  CONSTRAINT [DF_T_Islemler_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[T_Personeller] ADD  CONSTRAINT [DF_T_Personeller_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[T_Yonetim] ADD  CONSTRAINT [DF_T_Yonetim_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Admin]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Admin]
@Tc nvarchar(50),
@Sifre nvarchar(64)


as 
begin
Select yonetimID,Tc,Sifre From T_Yonetim where Tc = @Tc and Sifre = @Sifre
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ArizaDurumGuncelle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_ArizaDurumGuncelle]
@ID int,
@durumID int
AS
BEGIN
update T_Ariza set durumID=@durumID where ID=@ID

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ArizaEkle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_ArizaEkle]

@perID int,
@bildirimZamani datetime,
@Ariza nvarchar(150),
@arizaYeri nvarchar(150),
@teknisyenAta nvarchar(150),
@uzmanAta nvarchar(50)


as
begin
insert into T_Ariza(perID,bildirimZamani,Ariza,arizaYeri,teknisyenAta,uzmanAta,durumID) values (@perID,@bildirimZamani,@Ariza,@arizaYeri,@teknisyenAta,@uzmanAta,3)
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ArizaGuncelle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_ArizaGuncelle]
@ID int,


@islem varchar(max),
@MudahaleZamani datetime,
@malzemeID int

as
begin
update T_Ariza set islem=@islem,MudahaleZamani=@MudahaleZamani,malzemeID=@malzemeID,durumID=2 where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ArizaIptalEt]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Sp_ArizaIptalEt]

@ID int

as
begin
update T_Ariza set IsActive = 0 where ID = @ID

end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ArizaIptalList]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_ArizaIptalList]

as
begin

select T_Ariza.ID,T_Ariza.Ariza,T_Ariza.teknisyenAta,T_Yonetim.AdiSoyadi,T_Personeller.perAdSoyad,T_Ariza.arizaYeri
FROM T_Ariza 
LEFT JOIN T_Personeller
  ON T_Ariza.perID = T_Personeller.perID
LEFT JOIN T_Malzemeler
ON T_Ariza.malzemeID=T_Malzemeler.malzemeID
LEFT JOIN T_IsDurum
ON T_Ariza.durumID=T_IsDurum.durumID
LEFT JOIN T_Yonetim
ON T_Ariza.uzmanAta=T_Yonetim.Tc

where  T_Ariza.IsActive= 0

end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ArizaListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Sp_ArizaListele]


as
begin
SELECT T_Ariza.ID,T_Personeller.perAdSoyad,T_Ariza.Ariza,T_Ariza.arizaYeri,T_Yonetim.AdiSoyadi


FROM T_Ariza 
LEFT JOIN T_Personeller
  ON T_Ariza.perID = T_Personeller.perID
LEFT JOIN T_Malzemeler
ON T_Ariza.malzemeID=T_Malzemeler.malzemeID
LEFT JOIN T_IsDurum
ON T_Ariza.durumID=T_IsDurum.durumID
LEFT JOIN T_Yonetim
ON T_Ariza.uzmanAta=T_Yonetim.Tc

where T_Ariza.IsActive=1 and T_Ariza.durumID = 3

end
GO
/****** Object:  StoredProcedure [dbo].[Sp_BiligilerimiGuncelle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_BiligilerimiGuncelle]

@AdiSoyadi nvarchar(50),
@Tc nvarchar(50),
@Email nvarchar(50),
@Telefon nvarchar(50),
@Sifre nvarchar(64)



as
begin
update T_Yonetim set AdiSoyadi=@AdiSoyadi,Email=@Email,Telefon=@Telefon,Sifre=@Sifre where Tc=@Tc
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_IdyeGoreListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_IdyeGoreListele]
@uzmanAta nvarchar(50)
as
begin 
select ta.ID,tp.perAdSoyad,ta.bildirimZamani,ta.Ariza From T_Ariza ta

LEFT JOIN T_Personeller tp
ON ta.perID=tp.perID

where uzmanAta = @uzmanAta and durumID = 3
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_IsAra]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_IsAra]
@Ariza nvarchar(50),
@YonetimTc nvarchar(50),
@perTc nvarchar(50)

as
begin
select  T_Ariza.ID,T_Yonetim.AdiSoyadi,T_Personeller.perAdSoyad,T_Ariza.Ariza,T_Ariza.arizaYeri from T_Ariza
left join T_Yonetim on T_Yonetim.Tc = T_Ariza.uzmanAta 
left join T_Personeller on T_Personeller.perID = T_Ariza.perID 
where T_Ariza.Ariza like '%'+@Ariza+'%' or T_Yonetim.Tc like '%'+@YonetimTc+'%' or T_Personeller.perTc like '%'+@perTc+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_IslemEkle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_IslemEkle]

@islem nvarchar(50)



AS
BEGIN

	insert into T_Islemler(islem) values (@islem)

 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_IslemListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_IslemListele]

as
begin
select * from T_Islemler
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_IslemSil]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_IslemSil]

@islemID int



AS
BEGIN

	update T_Islemler set IsActive=0 where islemID=@islemID

 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_IslerimiListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_IslerimiListele]
@uzmanAta nvarchar(50)
as
begin 
select ta.ID,ta.Ariza,ta.arizaYeri,ta.teknisyenAta,tp.perAdSoyad,tp.perTelefon From T_Ariza ta

LEFT JOIN T_Personeller tp
ON ta.perID=tp.perID

where uzmanAta = @uzmanAta and durumID = 1
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_KabulArizaList]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_KabulArizaList]

as
begin

select T_Ariza.ID,T_Ariza.Ariza,T_Ariza.teknisyenAta,T_Yonetim.AdiSoyadi,T_Personeller.perAdSoyad,T_Ariza.arizaYeri
FROM T_Ariza 
LEFT JOIN T_Personeller
  ON T_Ariza.perID = T_Personeller.perID
LEFT JOIN T_Malzemeler
ON T_Ariza.malzemeID=T_Malzemeler.malzemeID
LEFT JOIN T_IsDurum
ON T_Ariza.durumID=T_IsDurum.durumID
LEFT JOIN T_Yonetim
ON T_Ariza.uzmanAta=T_Yonetim.Tc

where  T_Ariza.IsActive= 1 and T_Ariza.durumID = 1

end
GO
/****** Object:  StoredProcedure [dbo].[Sp_MalzemeEkle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_MalzemeEkle]

@malzemeAd nvarchar(50)



as
begin
insert into T_Malzemeler(malzemeAd) values (@malzemeAd)
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_MalzemeListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_MalzemeListele]

as
begin
select * from T_Malzemeler
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_MalzemeSil]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_MalzemeSil]
@malzemeID int




as
begin
delete from T_Malzemeler where malzemeID=@malzemeID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_PasifArizaListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_PasifArizaListele]


as
begin
SELECT T_Ariza.ID,T_Personeller.perAdSoyad,T_Ariza.bildirimZamani,T_Ariza.Ariza,T_Ariza.arizaYeri,T_Ariza.MudahaleZamani,
T_Malzemeler.malzemeAd,T_Ariza.teknisyenAta


FROM T_Ariza 
LEFT JOIN T_Personeller
  ON T_Ariza.perID = T_Personeller.perID
LEFT JOIN T_Malzemeler
ON T_Ariza.malzemeID=T_Malzemeler.malzemeID
LEFT JOIN T_IsDurum
ON T_Ariza.durumID=T_IsDurum.durumID

where T_Ariza.durumID=2;  /* T_IsDurum tablosunda tamamlanan Id = 2 */


end
GO
/****** Object:  StoredProcedure [dbo].[Sp_PersonelEkle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_PersonelEkle]

@perTc nvarchar(50),
@perAdSoyad nvarchar(50),
@perMail nvarchar(50),
@perTelefon nvarchar(50)



AS
BEGIN

	insert into T_Personeller(perTC,perAdSoyad,perTelefon,perMail) values (@perTC,@perAdSoyad,@perTelefon,@perMail)

 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_PersonelGuncelle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_PersonelGuncelle]

@perTc nvarchar(50),
@perAdSoyad nvarchar(50),
@perMail nvarchar(50),
@perTelefon nvarchar(50),
@perID int


AS
BEGIN

	update T_Personeller set perTc=@perTc,perAdSoyad=@perAdSoyad,perMail=@perMail,perTelefon=@perTelefon where perID=@perID

 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_PersonelListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_PersonelListele]




AS
BEGIN

	select  perID,perTc,perAdSoyad,perMail,perTelefon from T_Personeller where IsActive = 1

 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_PersonelSİl]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_PersonelSİl]


@perID int


AS
BEGIN

	update T_Personeller set IsActive = 0 where perID=@perID

 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_RaporEkle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_RaporEkle]
@ID int,
@rapor varchar(max)
as
begin
update T_Ariza set rapor =@rapor where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_RedArizaList]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_RedArizaList]

as
begin

select T_Ariza.ID,T_Yonetim.AdiSoyadi,T_Personeller.perAdSoyad,T_Ariza.Ariza,T_Ariza.arizaYeri
FROM T_Ariza 
LEFT JOIN T_Personeller
  ON T_Ariza.perID = T_Personeller.perID
LEFT JOIN T_Malzemeler
ON T_Ariza.malzemeID=T_Malzemeler.malzemeID
LEFT JOIN T_IsDurum
ON T_Ariza.durumID=T_IsDurum.durumID
LEFT JOIN T_Yonetim
ON T_Ariza.uzmanAta=T_Yonetim.Tc

where  T_Ariza.IsActive= 1 and T_Ariza.durumID = 4

end
GO
/****** Object:  StoredProcedure [dbo].[Sp_TeknisyenAra]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_TeknisyenAra]
@AdiSoyadi nvarchar(50)

as
begin
select * from T_Yonetim where AdiSoyadi = @AdiSoyadi and IsActive =1
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_TeknisyenEkle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_TeknisyenEkle]
@Asil nvarchar(50),
@yedek1 nvarchar(50),
@yedek2 nvarchar(50),
@yedek3 nvarchar(50)

as
begin
insert into T_TeknisyenAta (Asil,yedek1,yedek2,yedek3) values (@Asil,@yedek1,@yedek2,@yedek3)
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_TeknisyenListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_TeknisyenListele]

as 
begin
 select AdiSoyadi from T_Yonetim where yetkiID = 4 and IsActive = 1 Order by AdiSoyadi asc
 end
GO
/****** Object:  StoredProcedure [dbo].[Sp_UzmanListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_UzmanListele]

as 
begin
 select * from T_Yonetim where yetkiID = 3 and IsActive = 1 order By AdiSoyadi Asc 
 end
GO
/****** Object:  StoredProcedure [dbo].[Sp_VeriAl]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Sp_VeriAl]

as
begin 
select yonetimID,yetkiID  From T_Yonetim
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_YetkiListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_YetkiListele]

as
begin
select* From T_Yetkiler
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_YoneticiCagir]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_YoneticiCagir]
@tc nvarchar(50)
as
begin
select * from T_Yonetim where Tc=@tc and IsActive =1
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_YonetimEkle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_YonetimEkle]

@AdiSoyadi nvarchar(50),
@Tc nvarchar(50),
@Email nvarchar(50),
@Telefon nvarchar(50),
@Sifre nvarchar(64),
@yetkiID int


as
begin
insert into T_Yonetim(AdiSoyadi,Tc,Email,Telefon,Sifre,yetkiID) values (@AdiSoyadi,@Tc,@Email,@Telefon,@Sifre,@yetkiID)
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_YonetimGuncelle]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_YonetimGuncelle]
@yonetimID int,
@AdiSoyadi nvarchar(50),
@Tc nvarchar(50),
@Email nvarchar(50),
@Telefon nvarchar(50),
@Sifre nvarchar(64),
@yetkiID int


as
begin
update T_Yonetim set AdiSoyadi=@AdiSoyadi,Tc=@Tc,Email=@Email,Telefon=@Telefon,Sifre=@Sifre,yetkiID=@yetkiID where yonetimID=@yonetimID
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_YonetimListele]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_YonetimListele]


as
begin
SELECT T_Yonetim.yonetimID,T_Yonetim.AdiSoyadi,T_Yonetim.Tc,T_Yonetim.Email,T_Yonetim.Telefon,T_Yonetim.Sifre,T_Yetkiler.Yetki
FROM T_Yonetim
LEFT JOIN T_Yetkiler
  ON T_Yonetim.yetkiID = T_Yetkiler.yetkiID
	 where IsActive=1 ;
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_YonetimSil]    Script Date: 10.01.2022 14:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_YonetimSil]
@yonetimID int


as
begin
update T_Yonetim set IsActive=0 where yonetimID=@yonetimID

end
GO
USE [master]
GO
ALTER DATABASE [FaultsTracking] SET  READ_WRITE 
GO
