using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactDirectoriesLoader.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

              migrationBuilder.CreateTable(
            name: "BAD_DOC",
            columns: table => new
            {
              ID = table.Column<int>(type: "int", nullable: false),
              VERSION = table.Column<int>(type: "int", nullable: false),
              ERASED = table.Column<bool>(type: "bit", nullable: false),
              COUNTRY = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
              TYPDOC = table.Column<int>(type: "int", nullable: false),
              S_DOC = table.Column<string>(type: "nvarchar(80)", nullable: false),
              N_DOC = table.Column<string>(type: "nvarchar(80)", nullable: false),
              BLOCKED = table.Column<int>(type: "int", nullable: false),
              INFO = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
              INFO1 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
              c10 = table.Column<int>(type: "int", nullable: false),
              c11 = table.Column<int>(type: "int", nullable: false),
            },
            constraints: table =>
            {
              table.PrimaryKey("PK_BAD_DOC", x => x.ID);
            });



      migrationBuilder.CreateTable(
                name: "ATTRLIST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    GRP_NUM = table.Column<int>(type: "int", nullable: false),
                    IS_COND = table.Column<bool>(type: "bit", nullable: false),
                    SORTORDER = table.Column<int>(type: "int", nullable: false),
                    MIN_VALUE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MAX_VALUE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURR_CODE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CURR_USE_EQ = table.Column<int>(type: "int", nullable: false),
                    S_RESIDENT = table.Column<int>(type: "int", nullable: false),
                    FIELD_GRP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FIELD_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FIELD_CAPTION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FIELD_CAPTION_LAT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REG_MASK = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BIC = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    IS_REQUIRED = table.Column<bool>(type: "bit", nullable: false),
                    EXAMPLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    COMMENT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    COMMENT_LAT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MAX_LEN = table.Column<int>(type: "int", nullable: false),
                    EDIT_STATES = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SHORT_CAPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SHORT_CAPTION_LAT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    INOUTEDIT = table.Column<int>(type: "int", nullable: false),
                    DATA_TYPE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VISIBLE = table.Column<bool>(type: "bit", nullable: false),
                    CONTROL_MODE = table.Column<int>(type: "int", nullable: false),
                    LANG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTRLIST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BANKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    PARENT_ID = table.Column<int>(type: "int", nullable: true),
                    PP_CODE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    bic = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CITY_HEAD = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    ADDRESS1 = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    ADDRESS2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ADDRESS3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ADDRESS4 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NAME_RUS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    COUNTRY = table.Column<int>(type: "int", nullable: true),
                    DELETED = table.Column<bool>(type: "bit", nullable: true),
                    CITY_LAT = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    ADDR_LAT = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    CONTACT = table.Column<int>(type: "int", nullable: true),
                    REGION = table.Column<int>(type: "int", nullable: true),
                    IS_KFM = table.Column<bool>(type: "bit", nullable: true),
                    IS_ONLINE = table.Column<int>(type: "int", nullable: true),
                    CAN_REVOKE = table.Column<bool>(type: "bit", nullable: true),
                    CAN_CHANGE = table.Column<bool>(type: "bit", nullable: true),
                    GET_MONEY = table.Column<bool>(type: "bit", nullable: true),
                    SEND_CURR = table.Column<string>(type: "nvarchar(252)", maxLength: 252, nullable: true),
                    REC_CURR = table.Column<string>(type: "nvarchar(252)", maxLength: 252, nullable: true),
                    ATTR_GRPS = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    CITY_ID = table.Column<int>(type: "int", nullable: true),
                    LOGO_ID = table.Column<int>(type: "int", nullable: true),
                    SCEN_ID = table.Column<int>(type: "int", nullable: true),
                    UNIQUE_TRN = table.Column<bool>(type: "bit", nullable: true),
                    METRO = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANKS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BANKSERV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    BANK_ID = table.Column<int>(type: "int", nullable: false),
                    SERV_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANKSERV", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BNK_CITY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    CITY_HEAD = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CITY_LAT = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    COUNTRY = table.Column<int>(type: "int", nullable: true),
                    REGION = table.Column<int>(type: "int", nullable: true),
                    SEND_CURR = table.Column<string>(type: "nvarchar(252)", maxLength: 252, nullable: true),
                    REC_CURR = table.Column<string>(type: "nvarchar(252)", maxLength: 252, nullable: true),
                    PP_CODE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BNK_CITY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    NAME_LAT = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    CODE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SEND_CURR = table.Column<string>(type: "nvarchar(252)", maxLength: 252, nullable: true),
                    REC_CURR = table.Column<string>(type: "nvarchar(252)", maxLength: 252, nullable: true),
                    IS_FATF = table.Column<bool>(type: "bit", nullable: true),
                    PP_CODE = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FEAT_TXT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    FEATURE = table.Column<int>(type: "int", nullable: false),
                    LINE_NO = table.Column<int>(type: "int", nullable: false),
                    LINE_TEXT = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    XML_TEXT = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEAT_TXT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FEATURE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    SUBJ_TYPE = table.Column<int>(type: "int", nullable: false),
                    SUBJ_CODE = table.Column<int>(type: "int", nullable: false),
                    IS_PAYMENT = table.Column<bool>(type: "bit", nullable: false),
                    LANGUAGE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEATURE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KFM_INFO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    NAMEU_F = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAMEU_I = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAMEU_O = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BIRTHDAY = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    PASSPORT = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    DELETED = table.Column<bool>(type: "bit", nullable: false),
                    NAMEU = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KFM_INFO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOADING_INFO",
                columns: table => new
                {
                    LOADING_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    RESPONSE_IS_FULL = table.Column<bool>(type: "bit", nullable: false),
                    START_DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOADING_INFO", x => x.LOADING_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "LOGO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    LOGO_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LOGO_DATA_BLOB = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LOGO_DATA_LAT = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "METRO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    CITY = table.Column<int>(type: "int", nullable: false),
                    LINE = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METRO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "METRO_LINES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    CITY = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METRO_LINES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MIN_MAX",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    BANK_ID = table.Column<int>(type: "int", nullable: false),
                    CURR_CODE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    MIN_SUM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MAX_SUM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MIN_MAX", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REGION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    SUBDIVISION_ISOCODE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    COUNTRY = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NAME_SORT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NAME_LAT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SCEN_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    SCEN_ID = table.Column<int>(type: "int", nullable: false),
                    STEP = table.Column<int>(type: "int", nullable: false),
                    ATTR_GRPS = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    OBJECT_CLASS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OBJECT_ACTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LIST_SRC = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCEN_ITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SERV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    ERASED = table.Column<bool>(type: "bit", nullable: false),
                    PARENT_ID = table.Column<int>(type: "int", nullable: false),
                    CAPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    COMMENT = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    CAPTION_LA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    COMMENT_LA = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    CAN_IN = table.Column<bool>(type: "bit", nullable: false),
                    CAN_PAY = table.Column<bool>(type: "bit", nullable: false),
                    CS_IN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CS_IN_FEE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CS_PAY = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERV", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
      migrationBuilder.DropTable(
          name: "ATTRLIST");
      migrationBuilder.DropTable(
          name: "BAD_DOC");

      migrationBuilder.DropTable(
                name: "BANKS");

            migrationBuilder.DropTable(
                name: "BANKSERV");

            migrationBuilder.DropTable(
                name: "BNK_CITY");

            migrationBuilder.DropTable(
                name: "COUNTRY");

            migrationBuilder.DropTable(
                name: "FEAT_TXT");

            migrationBuilder.DropTable(
                name: "FEATURE");

            migrationBuilder.DropTable(
                name: "KFM_INFO");

            migrationBuilder.DropTable(
                name: "LOADING_INFO");

            migrationBuilder.DropTable(
                name: "LOGO");

            migrationBuilder.DropTable(
                name: "METRO");

            migrationBuilder.DropTable(
                name: "METRO_LINES");

            migrationBuilder.DropTable(
                name: "MIN_MAX");

            migrationBuilder.DropTable(
                name: "REGION");

            migrationBuilder.DropTable(
                name: "SCEN_ITEM");

            migrationBuilder.DropTable(
                name: "SERV");
        }
    }
}
