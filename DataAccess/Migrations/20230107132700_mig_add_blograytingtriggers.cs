using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migaddblograytingtriggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var addBlogRaytingTable = migrationBuilder.Sql($"Create Trigger AddBlogInRatingTable on Blogs After Insert As Declare @ID int Select @ID=BlogID from inserted Insert Into BlogRaytings (BlogID, BlogTotalScore, BlogCommentCount) Values (@ID, 0, 0)");

            var addScoreInComment = migrationBuilder.Sql($"Create Trigger AddScoreInComment on Comments after Insert as Declare @ID int Declare @BlogRaytingScore int Declare @BlogCommentCount int Select @ID=BlogID,@BlogRaytingScore=BlogRaytingScore from inserted Update BlogRaytings Set BlogTotalScore=BlogTotalScore+@BlogRaytingScore , BlogCommentCount+=1 where BlogID=@ID");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
