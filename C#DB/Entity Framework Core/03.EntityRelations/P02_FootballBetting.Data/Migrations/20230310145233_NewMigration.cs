using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_FootballBetting.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Game_GameId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_User_UserId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_AwayTeamId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_HomeTeamId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Position_PositionId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistic_Game_GameId",
                table: "PlayerStatistic");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistic_Player_PlayerId",
                table: "PlayerStatistic");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Color_PrimaryKitColorId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Color_SecondaryKitColorId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Town_TownId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Town_Country_CountryId",
                table: "Town");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Town",
                table: "Town");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerStatistic",
                table: "PlayerStatistic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bet",
                table: "Bet");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Town",
                newName: "Towns");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "PlayerStatistic",
                newName: "PlayerStatistics");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "Bet",
                newName: "Bets");

            migrationBuilder.RenameIndex(
                name: "IX_Town_CountryId",
                table: "Towns",
                newName: "IX_Towns_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_TownId",
                table: "Teams",
                newName: "IX_Teams_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_SecondaryKitColorId",
                table: "Teams",
                newName: "IX_Teams_SecondaryKitColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_PrimaryKitColorId",
                table: "Teams",
                newName: "IX_Teams_PrimaryKitColorId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerStatistic_PlayerId",
                table: "PlayerStatistics",
                newName: "IX_PlayerStatistics_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_TeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_PositionId",
                table: "Players",
                newName: "IX_Players_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_HomeTeamId",
                table: "Games",
                newName: "IX_Games_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_AwayTeamId",
                table: "Games",
                newName: "IX_Games_AwayTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UserId",
                table: "Bets",
                newName: "IX_Bets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_GameId",
                table: "Bets",
                newName: "IX_Bets_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Towns",
                table: "Towns",
                column: "TownId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerStatistics",
                table: "PlayerStatistics",
                columns: new[] { "GameId", "PlayerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bets",
                table: "Bets",
                column: "BetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Games_GameId",
                table: "Bets",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_AwayTeamId",
                table: "Games",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_HomeTeamId",
                table: "Games",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_Games_GameId",
                table: "PlayerStatistics",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_Players_PlayerId",
                table: "PlayerStatistics",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Colors_PrimaryKitColorId",
                table: "Teams",
                column: "PrimaryKitColorId",
                principalTable: "Colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Colors_SecondaryKitColorId",
                table: "Teams",
                column: "SecondaryKitColorId",
                principalTable: "Colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Towns_TownId",
                table: "Teams",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Games_GameId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_AwayTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_HomeTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_Games_GameId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_Players_PlayerId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Colors_PrimaryKitColorId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Colors_SecondaryKitColorId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Towns_TownId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Towns",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerStatistics",
                table: "PlayerStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bets",
                table: "Bets");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Towns",
                newName: "Town");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "PlayerStatistics",
                newName: "PlayerStatistic");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameTable(
                name: "Bets",
                newName: "Bet");

            migrationBuilder.RenameIndex(
                name: "IX_Towns_CountryId",
                table: "Town",
                newName: "IX_Town_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_TownId",
                table: "Team",
                newName: "IX_Team_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_SecondaryKitColorId",
                table: "Team",
                newName: "IX_Team_SecondaryKitColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_PrimaryKitColorId",
                table: "Team",
                newName: "IX_Team_PrimaryKitColorId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerStatistics_PlayerId",
                table: "PlayerStatistic",
                newName: "IX_PlayerStatistic_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Player",
                newName: "IX_Player_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PositionId",
                table: "Player",
                newName: "IX_Player_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_HomeTeamId",
                table: "Game",
                newName: "IX_Game_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_AwayTeamId",
                table: "Game",
                newName: "IX_Game_AwayTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_UserId",
                table: "Bet",
                newName: "IX_Bet_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_GameId",
                table: "Bet",
                newName: "IX_Bet_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Town",
                table: "Town",
                column: "TownId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerStatistic",
                table: "PlayerStatistic",
                columns: new[] { "GameId", "PlayerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bet",
                table: "Bet",
                column: "BetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Game_GameId",
                table: "Bet",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_User_UserId",
                table: "Bet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_AwayTeamId",
                table: "Game",
                column: "AwayTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_HomeTeamId",
                table: "Game",
                column: "HomeTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Position_PositionId",
                table: "Player",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistic_Game_GameId",
                table: "PlayerStatistic",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistic_Player_PlayerId",
                table: "PlayerStatistic",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Color_PrimaryKitColorId",
                table: "Team",
                column: "PrimaryKitColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Color_SecondaryKitColorId",
                table: "Team",
                column: "SecondaryKitColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Town_TownId",
                table: "Team",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Town_Country_CountryId",
                table: "Town",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
