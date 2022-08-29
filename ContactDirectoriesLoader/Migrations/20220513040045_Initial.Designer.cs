﻿// <auto-generated />
using System;
using ContactDirectoriesLoader.Repository.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactDirectoriesLoader.Migrations
{
    [DbContext(typeof(DictionariesDbContext))]
    [Migration("20220513040045_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);


      modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.BadDoc", b =>
      {
        b.Property<bool>("Erased")
        .HasColumnType("bit")
        .HasColumnName("ERASED");

        b.Property<int>("Version")
            .HasColumnType("int")
            .HasColumnName("VERSION");

        b.Property<int>("Id")
            .HasColumnType("int")
            .HasColumnName("ID");

        b.Property<string>("Country")
            .HasMaxLength(35)
            .HasColumnType("nvarchar(35)")
            .HasColumnName("COUNTRY");

        b.Property<int>("TypeDoc")
            .HasColumnType("int")
            .HasColumnName("TYPDOC");

        b.Property<int>("sDoc")
            .HasColumnType("int")
            .HasColumnName("S_DOC");
        b.Property<int>("nDoc")
            .HasColumnType("int")
            .HasColumnName("N_DOC");

        b.Property<int>("blocked")
            .HasColumnType("int")
            .HasColumnName("BLOCKED");
        b.Property<int>("c10")
            .HasColumnType("int")
            .HasColumnName("c10");
        b.Property<int>("c11")
            .HasColumnType("int")
            .HasColumnName("c11");


        b.Property<string>("info")
            .HasMaxLength(35)
            .HasColumnType("nvarchar(255)")
            .HasColumnName("INFO");

        b.Property<string>("info1")
            .HasMaxLength(35)
            .HasColumnType("nvarchar(255)")
            .HasColumnName("INFO1");

        b.HasKey("Id");

        b.ToTable("BAD_DOC");
      });



      modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)")
                        .HasColumnName("ADDRESS1");

                    b.Property<string>("AddressLat")
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)")
                        .HasColumnName("ADDR_LAT");

                    b.Property<string>("AttributeGroups")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)")
                        .HasColumnName("ATTR_GRPS");

                    b.Property<string>("Bic")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("bic");

                    b.Property<bool?>("CanChange")
                        .HasColumnType("bit")
                        .HasColumnName("CAN_CHANGE");

                    b.Property<bool?>("CanRevoke")
                        .HasColumnType("bit")
                        .HasColumnName("CAN_REVOKE");

                    b.Property<string>("CityHead")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("CITY_HEAD");

                    b.Property<int?>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CITY_ID");

                    b.Property<string>("CityLat")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("CITY_LAT");

                    b.Property<int?>("Contact")
                        .HasColumnType("int")
                        .HasColumnName("CONTACT");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("COUNTRY");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("DELETED");

                    b.Property<bool?>("IsKfm")
                        .HasColumnType("bit")
                        .HasColumnName("IS_KFM");

                    b.Property<int?>("IsOnline")
                        .HasColumnType("int")
                        .HasColumnName("IS_ONLINE");

                    b.Property<int?>("LogoId")
                        .HasColumnType("int")
                        .HasColumnName("LOGO_ID");

                    b.Property<bool?>("MetroId")
                        .HasColumnType("bit")
                        .HasColumnName("METRO");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NAME");

                    b.Property<string>("NameRus")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME_RUS");

                    b.Property<bool?>("NeedGetMoney")
                        .HasColumnType("bit")
                        .HasColumnName("GET_MONEY");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ID");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PHONE");

                    b.Property<string>("PointCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("PP_CODE");

                    b.Property<string>("ReceivingCurrencies")
                        .HasMaxLength(252)
                        .HasColumnType("nvarchar(252)")
                        .HasColumnName("REC_CURR");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int")
                        .HasColumnName("REGION");

                    b.Property<string>("ReservedAddress")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("ADDRESS4");

                    b.Property<int?>("ScenId")
                        .HasColumnType("int")
                        .HasColumnName("SCEN_ID");

                    b.Property<string>("SendingCurrencies")
                        .HasMaxLength(252)
                        .HasColumnType("nvarchar(252)")
                        .HasColumnName("SEND_CURR");

                    b.Property<bool?>("UniqueTrn")
                        .HasColumnType("bit")
                        .HasColumnName("UNIQUE_TRN");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.Property<string>("WeekendsHours")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("ADDRESS3");

                    b.Property<string>("WorkingHours")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("ADDRESS2");

                    b.HasKey("Id");

                    b.ToTable("BANKS");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.BankCity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("CityHead")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("CITY_HEAD");

                    b.Property<string>("CityLat")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("CITY_LAT");

                    b.Property<int?>("Country")
                        .HasColumnType("int")
                        .HasColumnName("COUNTRY");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<string>("PointCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("PP_CODE");

                    b.Property<string>("ReceivingCurrencies")
                        .HasMaxLength(252)
                        .HasColumnType("nvarchar(252)")
                        .HasColumnName("REC_CURR");

                    b.Property<int?>("Region")
                        .HasColumnType("int")
                        .HasColumnName("REGION");

                    b.Property<string>("SendingCurrencies")
                        .HasMaxLength(252)
                        .HasColumnType("nvarchar(252)")
                        .HasColumnName("SEND_CURR");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("BNK_CITY");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.BankServ", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("BankId")
                        .HasColumnType("int")
                        .HasColumnName("BANK_ID");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<int>("ServId")
                        .HasColumnType("int")
                        .HasColumnName("SERV_ID");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("BANKSERV");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.ControlRule", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Bic")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("BIC");

                    b.Property<string>("Comment")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("COMMENT");

                    b.Property<string>("CommentLat")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("COMMENT_LAT");

                    b.Property<int>("ControlMode")
                        .HasColumnType("int")
                        .HasColumnName("CONTROL_MODE");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("CURR_CODE");

                    b.Property<int>("CurrencyUseEquivalent")
                        .HasColumnType("int")
                        .HasColumnName("CURR_USE_EQ");

                    b.Property<string>("DataType")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("DATA_TYPE");

                    b.Property<string>("EditStates")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EDIT_STATES");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<string>("Example")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EXAMPLE");

                    b.Property<string>("FieldCaption")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FIELD_CAPTION");

                    b.Property<string>("FieldCaptionLat")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FIELD_CAPTION_LAT");

                    b.Property<string>("FieldGroup")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FIELD_GRP");

                    b.Property<string>("FieldName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FIELD_NAME");

                    b.Property<int>("GroupNumber")
                        .HasColumnType("int")
                        .HasColumnName("GRP_NUM");

                    b.Property<int>("InOutEdit")
                        .HasColumnType("int")
                        .HasColumnName("INOUTEDIT");

                    b.Property<bool>("IsCond")
                        .HasColumnType("bit")
                        .HasColumnName("IS_COND");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit")
                        .HasColumnName("IS_REQUIRED");

                    b.Property<string>("Lang")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("LANG");

                    b.Property<int>("MaxLenght")
                        .HasColumnType("int")
                        .HasColumnName("MAX_LEN");

                    b.Property<decimal>("MaxValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MAX_VALUE");

                    b.Property<decimal>("MinValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MIN_VALUE");

                    b.Property<string>("RegularMask")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("REG_MASK");

                    b.Property<int>("SenderResident")
                        .HasColumnType("int")
                        .HasColumnName("S_RESIDENT");

                    b.Property<string>("ShortCaption")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SHORT_CAPTION");

                    b.Property<string>("ShortCaptionLat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SHORT_CAPTION_LAT");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int")
                        .HasColumnName("SORTORDER");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit")
                        .HasColumnName("VISIBLE");

                    b.HasKey("Id");

                    b.ToTable("ATTRLIST");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("CODE");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<bool?>("IsFatf")
                        .HasColumnType("bit")
                        .HasColumnName("IS_FATF");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("NAME");

                    b.Property<string>("NameLat")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("NAME_LAT");

                    b.Property<string>("PointCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("PP_CODE");

                    b.Property<string>("ReceivingCurrencies")
                        .HasMaxLength(252)
                        .HasColumnType("nvarchar(252)")
                        .HasColumnName("REC_CURR");

                    b.Property<string>("SendingCurrencies")
                        .HasMaxLength(252)
                        .HasColumnType("nvarchar(252)")
                        .HasColumnName("SEND_CURR");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("COUNTRY");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.Feature", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<bool>("IsPayment")
                        .HasColumnType("bit")
                        .HasColumnName("IS_PAYMENT");

                    b.Property<int>("Language")
                        .HasColumnType("int")
                        .HasColumnName("LANGUAGE");

                    b.Property<int>("SubjectCode")
                        .HasColumnType("int")
                        .HasColumnName("SUBJ_CODE");

                    b.Property<int>("SubjectType")
                        .HasColumnType("int")
                        .HasColumnName("SUBJ_TYPE");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("FEATURE");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.FeatureCaption", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int")
                        .HasColumnName("FEATURE");

                    b.Property<int>("LineNumber")
                        .HasColumnType("int")
                        .HasColumnName("LINE_NO");

                    b.Property<string>("LineText")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("LINE_TEXT");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.Property<string>("XmlText")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("XML_TEXT");

                    b.HasKey("Id");

                    b.ToTable("FEAT_TXT");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.FinancialMonitoringInfo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("Birthday")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("BIRTHDAY");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit")
                        .HasColumnName("DELETED");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAMEU_I");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAMEU_F");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAMEU_O");

                    b.Property<string>("NameU")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NAMEU");

                    b.Property<string>("Passport")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("PASSPORT");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("KFM_INFO");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.Limit", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("BankId")
                        .HasColumnType("int")
                        .HasColumnName("BANK_ID");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("CURR_CODE");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<decimal>("MaxSum")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MAX_SUM");

                    b.Property<decimal>("MinSum")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MIN_SUM");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("MIN_MAX");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.LoadingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LOADING_INFO_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("END_DATE_TIME");

                    b.Property<bool>("ResponseIsFull")
                        .HasColumnType("bit")
                        .HasColumnName("RESPONSE_IS_FULL");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("START_DATE_TIME");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("LOADING_INFO");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.Logo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<byte[]>("LogoDataBlob")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("LOGO_DATA_BLOB");

                    b.Property<byte[]>("LogoDataLat")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("LOGO_DATA_LAT");

                    b.Property<string>("LogoName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LOGO_NAME");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("LOGO");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.MetroLine", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("City")
                        .HasColumnType("int")
                        .HasColumnName("CITY");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("METRO_LINES");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.MetroStation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("City")
                        .HasColumnType("int")
                        .HasColumnName("CITY");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<int>("LineId")
                        .HasColumnType("int")
                        .HasColumnName("LINE");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("METRO");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Country")
                        .HasColumnType("int")
                        .HasColumnName("COUNTRY");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("NAME");

                    b.Property<string>("NameLat")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("NAME_LAT");

                    b.Property<string>("NameSort")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("NAME_SORT");

                    b.Property<string>("SubdivisionIsoCode")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("SUBDIVISION_ISOCODE");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("REGION");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.ScenarioItem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("AttributeGroups")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)")
                        .HasColumnName("ATTR_GRPS");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<string>("ListSources")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnName("LIST_SRC");

                    b.Property<string>("ObjectAction")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("OBJECT_ACTION");

                    b.Property<string>("ObjectClass")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("OBJECT_CLASS");

                    b.Property<int>("ScenaioId")
                        .HasColumnType("int")
                        .HasColumnName("SCEN_ID");

                    b.Property<int>("Step")
                        .HasColumnType("int")
                        .HasColumnName("STEP");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("SCEN_ITEM");
                });

            modelBuilder.Entity("ContactDirectoriesLoader.Repository.Entities.Serv", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool>("CanIn")
                        .HasColumnType("bit")
                        .HasColumnName("CAN_IN");

                    b.Property<bool>("CanPay")
                        .HasColumnType("bit")
                        .HasColumnName("CAN_PAY");

                    b.Property<string>("Caption")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CAPTION");

                    b.Property<string>("CaptionLat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CAPTION_LA");

                    b.Property<string>("Comment")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("COMMENT");

                    b.Property<string>("CommentLat")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("COMMENT_LA");

                    b.Property<string>("CsIn")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CS_IN");

                    b.Property<string>("CsPay")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CS_PAY");

                    b.Property<string>("CsinFee")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CS_IN_FEE");

                    b.Property<bool>("Erased")
                        .HasColumnType("bit")
                        .HasColumnName("ERASED");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ID");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("VERSION");

                    b.HasKey("Id");

                    b.ToTable("SERV");
                });
#pragma warning restore 612, 618
        }
    }
}
