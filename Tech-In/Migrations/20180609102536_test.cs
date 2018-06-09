using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tech_In.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(maxLength: 50, nullable: false),
                    CountryPhoneCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillTag",
                columns: table => new
                {
                    SkillTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedStatus = table.Column<bool>(nullable: false),
                    SkillName = table.Column<string>(maxLength: 20, nullable: false),
                    TimeApproved = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTag", x => x.SkillTagId);
                    table.ForeignKey(
                        name: "FK_SkillTag_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAcheivement",
                columns: table => new
                {
                    UserAchievementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 70, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAcheivement", x => x.UserAchievementId);
                    table.ForeignKey(
                        name: "FK_UserAcheivement_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCertification",
                columns: table => new
                {
                    UserCertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertificationDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    LiscenceNo = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    URL = table.Column<string>(maxLength: 200, nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCertification", x => x.UserCertificationId);
                    table.ForeignKey(
                        name: "FK_UserCertification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserHobby",
                columns: table => new
                {
                    UserHobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HobbyOrIntrest = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHobby", x => x.UserHobbyId);
                    table.ForeignKey(
                        name: "FK_UserHobby_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguageSkill",
                columns: table => new
                {
                    LanguageSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguageSkill", x => x.LanguageSkillId);
                    table.ForeignKey(
                        name: "FK_UserLanguageSkill_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPublication",
                columns: table => new
                {
                    UserPublicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConferenceOrJournal = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    PublishYear = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPublication", x => x.UserPublicationId);
                    table.ForeignKey(
                        name: "FK_UserPublication_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestion",
                columns: table => new
                {
                    UserQuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    PostTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestion", x => x.UserQuestionId);
                    table.ForeignKey(
                        name: "FK_UserQuestion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserSkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillTagId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.UserSkillID);
                    table.ForeignKey(
                        name: "FK_UserSkill_SkillTag_SkillTagId",
                        column: x => x.SkillTagId,
                        principalTable: "SkillTag",
                        principalColumn: "SkillTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSkill",
                columns: table => new
                {
                    QuestionSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillTagId = table.Column<int>(nullable: false),
                    UserQuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSkill", x => x.QuestionSkillId);
                    table.ForeignKey(
                        name: "FK_QuestionSkill_SkillTag_SkillTagId",
                        column: x => x.SkillTagId,
                        principalTable: "SkillTag",
                        principalColumn: "SkillTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionSkill_UserQuestion_UserQuestionId",
                        column: x => x.UserQuestionId,
                        principalTable: "UserQuestion",
                        principalColumn: "UserQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQAnswer",
                columns: table => new
                {
                    UserQAnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    PostTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserQuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQAnswer", x => x.UserQAnswerId);
                    table.ForeignKey(
                        name: "FK_UserQAnswer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQAnswer_UserQuestion_UserQuestionId",
                        column: x => x.UserQuestionId,
                        principalTable: "UserQuestion",
                        principalColumn: "UserQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEducation",
                columns: table => new
                {
                    UserEducationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    CurrentStatusCheck = table.Column<bool>(nullable: false),
                    Details = table.Column<string>(maxLength: 200, nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SchoolName = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducation", x => x.UserEducationId);
                    table.ForeignKey(
                        name: "FK_UserEducation_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEducation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserExperience",
                columns: table => new
                {
                    UserExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityID = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    CurrentWorkCheck = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExperience", x => x.UserExperienceId);
                    table.ForeignKey(
                        name: "FK_UserExperience_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExperience_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPersonalDetail",
                columns: table => new
                {
                    UserPersonalDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    CoverImage = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IsDOBPublic = table.Column<bool>(nullable: false),
                    IsEmailPublic = table.Column<bool>(nullable: false),
                    IsPhonePublic = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(maxLength: 300, nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonalDetail", x => x.UserPersonalDetailId);
                    table.ForeignKey(
                        name: "FK_UserPersonalDetail_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPersonalDetail_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserQAComment",
                columns: table => new
                {
                    UserQACommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    IsAnswer = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserQAnswerId = table.Column<int>(nullable: true),
                    UserQuestionId = table.Column<int>(nullable: true),
                    Visibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQAComment", x => x.UserQACommentID);
                    table.ForeignKey(
                        name: "FK_UserQAComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQAComment_UserQAnswer_UserQAnswerId",
                        column: x => x.UserQAnswerId,
                        principalTable: "UserQAnswer",
                        principalColumn: "UserQAnswerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQAComment_UserQuestion_UserQuestionId",
                        column: x => x.UserQuestionId,
                        principalTable: "UserQuestion",
                        principalColumn: "UserQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserQAVoting",
                columns: table => new
                {
                    UserQAVotingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAnswer = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserQAnswerId = table.Column<int>(nullable: true),
                    UserQuestionId = table.Column<int>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Visibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQAVoting", x => x.UserQAVotingID);
                    table.ForeignKey(
                        name: "FK_UserQAVoting_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQAVoting_UserQAnswer_UserQAnswerId",
                        column: x => x.UserQAnswerId,
                        principalTable: "UserQAnswer",
                        principalColumn: "UserQAnswerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserQAVoting_UserQuestion_UserQuestionId",
                        column: x => x.UserQuestionId,
                        principalTable: "UserQuestion",
                        principalColumn: "UserQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSkill_SkillTagId",
                table: "QuestionSkill",
                column: "SkillTagId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSkill_UserQuestionId",
                table: "QuestionSkill",
                column: "UserQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTag_UserId",
                table: "SkillTag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAcheivement_UserId",
                table: "UserAcheivement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertification_UserId",
                table: "UserCertification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_CityId",
                table: "UserEducation",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_UserId",
                table: "UserEducation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperience_CityID",
                table: "UserExperience",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperience_UserId",
                table: "UserExperience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHobby_UserId",
                table: "UserHobby",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguageSkill_UserId",
                table: "UserLanguageSkill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalDetail_CityId",
                table: "UserPersonalDetail",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalDetail_UserId",
                table: "UserPersonalDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPublication_UserId",
                table: "UserPublication",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAComment_UserId",
                table: "UserQAComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAComment_UserQAnswerId",
                table: "UserQAComment",
                column: "UserQAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAComment_UserQuestionId",
                table: "UserQAComment",
                column: "UserQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAnswer_UserId",
                table: "UserQAnswer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAnswer_UserQuestionId",
                table: "UserQAnswer",
                column: "UserQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAVoting_UserId",
                table: "UserQAVoting",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAVoting_UserQAnswerId",
                table: "UserQAVoting",
                column: "UserQAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQAVoting_UserQuestionId",
                table: "UserQAVoting",
                column: "UserQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestion_UserId",
                table: "UserQuestion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillTagId",
                table: "UserSkill",
                column: "SkillTagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                table: "UserSkill",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "QuestionSkill");

            migrationBuilder.DropTable(
                name: "UserAcheivement");

            migrationBuilder.DropTable(
                name: "UserCertification");

            migrationBuilder.DropTable(
                name: "UserEducation");

            migrationBuilder.DropTable(
                name: "UserExperience");

            migrationBuilder.DropTable(
                name: "UserHobby");

            migrationBuilder.DropTable(
                name: "UserLanguageSkill");

            migrationBuilder.DropTable(
                name: "UserPersonalDetail");

            migrationBuilder.DropTable(
                name: "UserPublication");

            migrationBuilder.DropTable(
                name: "UserQAComment");

            migrationBuilder.DropTable(
                name: "UserQAVoting");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "UserQAnswer");

            migrationBuilder.DropTable(
                name: "SkillTag");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "UserQuestion");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
