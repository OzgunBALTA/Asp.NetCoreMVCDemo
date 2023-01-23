using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migadduseroperationclaimtrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var addUserOperationClaimsTable = migrationBuilder.Sql($"Create Trigger AddUserOperationClaimsTable on Users After Insert As Declare @Id int Select @Id=Id from inserted Insert Into UserOperationClaims (UserId, OperationClaimId) Values (@Id, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
