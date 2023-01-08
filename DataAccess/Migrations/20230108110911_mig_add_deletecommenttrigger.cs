using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migadddeletecommenttrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var addScoreInComment = migrationBuilder.Sql($"Create Trigger DeleteScoreInComment on Comments After Delete as Declare @ID int Declare @BlogRaytingScore int Declare @BlogCommentCount int Select @ID=BlogID, @BlogRaytingScore=BlogRaytingScore from deleted Update BlogRaytings Set BlogTotalScore=BlogTotalScore-@BlogRaytingScore , BlogCommentCount-=1 where BlogID=@ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
