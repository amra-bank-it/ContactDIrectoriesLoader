using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactDirectoriesLoader.Migrations
{
    public partial class ClearContactDirectories : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sp = @"
						go

						if exists (
									select 1 from sys.procedures with (nolock) 
									where 
										name = 'ClearContactDirectories' 
										and
										type = 'P'
								  )
						drop procedure  dbo.ClearContactDirectories

						go

						create procedure dbo.ClearContactDirectories as
						begin
							if object_id('dbo.ATTRLIST') is not null truncate table dbo.ATTRLIST;
							if object_id('dbo.BANKS') is not null truncate table dbo.BANKS;
							if object_id('dbo.BAD_DOC') is not null truncate table dbo.BAD_DOC;
							if object_id('dbo.BANKSERV') is not null truncate table dbo.BANKSERV;
							if object_id('dbo.BNK_CITY') is not null truncate table dbo.BNK_CITY;
							if object_id('dbo.KFM_INFO') is not null truncate table dbo.KFM_INFO;
							if object_id('dbo.COUNTRY') is not null truncate table dbo.COUNTRY;
							if object_id('dbo.FEAT_TXT') is not null truncate table dbo.FEAT_TXT;
							if object_id('dbo.FEATURE') is not null truncate table dbo.FEATURE;
							if object_id('dbo.KFM_INFO') is not null truncate table dbo.KFM_INFO;
							if object_id('dbo.LOGO') is not null truncate table dbo.LOGO;
							if object_id('dbo.METRO') is not null truncate table dbo.METRO;
							if object_id('dbo.METRO_LINES') is not null truncate table dbo.METRO_LINES;
							if object_id('dbo.MIN_MAX') is not null truncate table dbo.MIN_MAX;
							if object_id('dbo.REGION') is not null truncate table dbo.REGION;
							if object_id('dbo.SCEN_ITEM') is not null truncate table dbo.SCEN_ITEM;
							if object_id('dbo.SERV') is not null truncate table dbo.SERV;
						end

            ";
			migrationBuilder.Sql(sp);
		}
    }
}
