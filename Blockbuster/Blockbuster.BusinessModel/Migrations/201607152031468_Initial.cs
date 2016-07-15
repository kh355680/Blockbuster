namespace Blockbuster.BusinessModel.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCasts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MovieId = c.String(maxLength: 128),
                        ArtistId = c.String(maxLength: 128),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .ForeignKey("dbo.Movies", t => t.MovieId)
                .Index(t => t.MovieId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Summary = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        GenreId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCasts", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieCasts", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.MovieCasts", new[] { "ArtistId" });
            DropIndex("dbo.MovieCasts", new[] { "MovieId" });
            DropTable("dbo.Movies");
            DropTable("dbo.MovieCasts");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
        }
    }
}
