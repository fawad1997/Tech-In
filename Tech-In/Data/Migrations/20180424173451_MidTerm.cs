using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tech_In.Data.Migrations
{
    public partial class MidTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExperiences_Companies_CompanyID",
                table: "UserExperiences");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_UserExperiences_CompanyID",
                table: "UserExperiences");

            migrationBuilder.DropColumn(
                name: "DOBVisibility",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "EmailVisibility",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "PhonoNoVisibility",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "UserExperiences");

            migrationBuilder.RenameColumn(
                name: "ExpTo",
                table: "UserExperiences",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "ExpFrom",
                table: "UserExperiences",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "CurrentStatus",
                table: "UserExperiences",
                newName: "CurrentWorkCheck");

            migrationBuilder.RenameColumn(
                name: "EduTo",
                table: "UserEducations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EduFrom",
                table: "UserEducations",
                newName: "EndDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsDOBPublic",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailPublic",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhonePublic",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "skillTags",
                columns: table => new
                {
                    SkillTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedByUserId = table.Column<string>(nullable: true),
                    ApprovedStatus = table.Column<bool>(nullable: false),
                    SkillName = table.Column<string>(maxLength: 20, nullable: false),
                    TimeApproved = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skillTags", x => x.SkillTagID);
                });

            migrationBuilder.CreateTable(
                name: "UserCertifications",
                columns: table => new
                {
                    UserCertificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertificationDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    LiscenceNo = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    URL = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCertifications", x => x.UserCertificationID);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    UserQuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    PostTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => x.UserQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    UserSkillID = table.Column<string>(nullable: false),
                    SkillTagID = table.Column<int>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.UserSkillID);
                    table.ForeignKey(
                        name: "FK_UserSkills_skillTags_SkillTagID",
                        column: x => x.SkillTagID,
                        principalTable: "skillTags",
                        principalColumn: "SkillTagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserQAnswers",
                columns: table => new
                {
                    UserQAnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    PostTime = table.Column<DateTime>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQAnswers", x => x.UserQAnswerID);
                    table.ForeignKey(
                        name: "FK_UserQAnswers_UserQuestions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "UserQuestions",
                        principalColumn: "UserQuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQAComments",
                columns: table => new
                {
                    UserQACommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerUserQAnswerID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsAnswer = table.Column<bool>(nullable: false),
                    QuestionUserQuestionID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Visibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQAComments", x => x.UserQACommentID);
                    table.ForeignKey(
                        name: "FK_UserQAComments_UserQAnswers_AnswerUserQAnswerID",
                        column: x => x.AnswerUserQAnswerID,
                        principalTable: "UserQAnswers",
                        principalColumn: "UserQAnswerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQAComments_UserQuestions_QuestionUserQuestionID",
                        column: x => x.QuestionUserQuestionID,
                        principalTable: "UserQuestions",
                        principalColumn: "UserQuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserQAVotings",
                columns: table => new
                {
                    UserQAVotingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerUserQAnswerID = table.Column<int>(nullable: true),
                    IsAnswer = table.Column<bool>(nullable: false),
                    QuestionUserQuestionID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Visibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQAVotings", x => x.UserQAVotingID);
                    table.ForeignKey(
                        name: "FK_UserQAVotings_UserQAnswers_AnswerUserQAnswerID",
                        column: x => x.AnswerUserQAnswerID,
                        principalTable: "UserQAnswers",
                        principalColumn: "UserQAnswerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQAVotings_UserQuestions_QuestionUserQuestionID",
                        column: x => x.QuestionUserQuestionID,
                        principalTable: "UserQuestions",
                        principalColumn: "UserQuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserQAComments_AnswerUserQAnswerID",
                table: "UserQAComments",
                column: "AnswerUserQAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAComments_QuestionUserQuestionID",
                table: "UserQAComments",
                column: "QuestionUserQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAnswers_QuestionID",
                table: "UserQAnswers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAVotings_AnswerUserQAnswerID",
                table: "UserQAVotings",
                column: "AnswerUserQAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAVotings_QuestionUserQuestionID",
                table: "UserQAVotings",
                column: "QuestionUserQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillTagID",
                table: "UserSkills",
                column: "SkillTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCertifications");

            migrationBuilder.DropTable(
                name: "UserQAComments");

            migrationBuilder.DropTable(
                name: "UserQAVotings");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "UserQAnswers");

            migrationBuilder.DropTable(
                name: "skillTags");

            migrationBuilder.DropTable(
                name: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "IsDOBPublic",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "IsEmailPublic",
                table: "UserPersonalDetails");

            migrationBuilder.DropColumn(
                name: "IsPhonePublic",
                table: "UserPersonalDetails");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "UserExperiences",
                newName: "ExpTo");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "UserExperiences",
                newName: "ExpFrom");

            migrationBuilder.RenameColumn(
                name: "CurrentWorkCheck",
                table: "UserExperiences",
                newName: "CurrentStatus");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "UserEducations",
                newName: "EduTo");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "UserEducations",
                newName: "EduFrom");

            migrationBuilder.AddColumn<short>(
                name: "DOBVisibility",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "EmailVisibility",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PhonoNoVisibility",
                table: "UserPersonalDetails",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "UserExperiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_CompanyID",
                table: "UserExperiences",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExperiences_Companies_CompanyID",
                table: "UserExperiences",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
