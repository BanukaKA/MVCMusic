﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Music.Data
{
    public static class ExtraMigration
    {
        public static void Steps(MigrationBuilder migrationBuilder)
        {
            //Triggers for Musician
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetMusicianTimestampOnUpdate
                    AFTER UPDATE ON Musicians
                    BEGIN
                        UPDATE Musicians
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetMusicianTimestampOnInsert
                    AFTER INSERT ON Musicians
                    BEGIN
                        UPDATE Musicians
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");

            //Triggers for Album
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetAlbumTimestampOnUpdate
                    AFTER UPDATE ON Albums
                    BEGIN
                        UPDATE Albums
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetAlbumTimestampOnInsert
                    AFTER INSERT ON Albums
                    BEGIN
                        UPDATE Albums
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");

            //Triggers for Song
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetSongTimestampOnUpdate
                    AFTER UPDATE ON Songs
                    BEGIN
                        UPDATE Songs
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetSongTimestampOnInsert
                    AFTER INSERT ON Songs
                    BEGIN
                        UPDATE Songs
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");

            migrationBuilder.Sql(
                @"
                    CREATE VIEW PerformanceSummaries as
                    Select p.ID, m.LastName + "", "" + m.FirstName as FormalName, AVG(p.FeePaid) as AverageFeePaid, Max(p.FeePaid) as HighestFeePaid, Min(p.FeePaid) as LowestFeePaid, COUNT(*) as TotalNumberOfPerformances 
                    From Performances p join Musicians m
                    on p.MusicianID = m.ID
                    Group By p.ID, m.FirstName, m.LastName;

                ");
        }
    }
}
