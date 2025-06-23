using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlineJobPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "application");

            migrationBuilder.EnsureSchema(
                name: "info");

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone_number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    details = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_cities",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_currencies",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_languages",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_levels",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_professions",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_professions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_roles",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_statuses",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_types_of_employment",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_types_of_employment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "info_working_hours",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_working_hours", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    level = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    method = table.Column<string>(type: "text", nullable: false),
                    status_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "otps",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone_number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    is_expired = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "work_experiences",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    website = table.Column<string>(type: "text", nullable: false),
                    details = table.Column<string>(type: "text", nullable: true),
                    job_title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    getting_started = table.Column<DateOnly>(type: "date", nullable: false),
                    ending = table.Column<DateOnly>(type: "date", nullable: false),
                    responsibilities = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_experiences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_info_cities_city_id",
                        column: x => x.city_id,
                        principalSchema: "info",
                        principalTable: "info_cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    faculty = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    graduation_year = table.Column<DateOnly>(type: "date", nullable: false),
                    level_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.id);
                    table.ForeignKey(
                        name: "FK_educations_info_levels_level_id",
                        column: x => x.level_id,
                        principalSchema: "info",
                        principalTable: "info_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_skills",
                schema: "info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    level_id = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_skills", x => x.id);
                    table.ForeignKey(
                        name: "FK_info_skills_info_levels_level_id",
                        column: x => x.level_id,
                        principalSchema: "info",
                        principalTable: "info_levels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    city_id = table.Column<int>(type: "integer", nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    language_level_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_info_cities_city_id",
                        column: x => x.city_id,
                        principalSchema: "info",
                        principalTable: "info_cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_info_languages_language_id",
                        column: x => x.language_id,
                        principalSchema: "info",
                        principalTable: "info_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_info_levels_language_level_id",
                        column: x => x.language_level_id,
                        principalSchema: "info",
                        principalTable: "info_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_info_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "info",
                        principalTable: "info_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_info_statuses_status_id",
                        column: x => x.status_id,
                        principalSchema: "info",
                        principalTable: "info_statuses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vacancies",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    profession_id = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    is_favourite = table.Column<bool>(type: "boolean", nullable: false),
                    responsibilities = table.Column<string>(type: "text", nullable: false),
                    details = table.Column<string>(type: "text", nullable: true),
                    working_hour_id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    type_of_employment = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacancies", x => x.id);
                    table.ForeignKey(
                        name: "FK_vacancies_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "application",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vacancies_info_professions_profession_id",
                        column: x => x.profession_id,
                        principalSchema: "info",
                        principalTable: "info_professions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vacancies_info_types_of_employment_type_of_employment",
                        column: x => x.type_of_employment,
                        principalSchema: "info",
                        principalTable: "info_types_of_employment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vacancies_info_working_hours_working_hour_id",
                        column: x => x.working_hour_id,
                        principalSchema: "info",
                        principalTable: "info_working_hours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contents",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    content_type = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contents", x => x.id);
                    table.ForeignKey(
                        name: "FK_contents_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resumes",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    profession_id = table.Column<int>(type: "integer", nullable: false),
                    working_hour_id = table.Column<int>(type: "integer", nullable: false),
                    currency_id = table.Column<int>(type: "integer", nullable: false),
                    type_of_employment_id = table.Column<int>(type: "integer", nullable: false),
                    contact_id = table.Column<int>(type: "integer", nullable: false),
                    work_experiance_id = table.Column<int>(type: "integer", nullable: false),
                    education_id = table.Column<int>(type: "integer", nullable: false),
                    skill_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    income_level_per_month = table.Column<decimal>(type: "numeric", nullable: false),
                    specializations = table.Column<string>(type: "text", nullable: false),
                    about_me = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    is_hided = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resumes", x => x.id);
                    table.ForeignKey(
                        name: "FK_resumes_contacts_contact_id",
                        column: x => x.contact_id,
                        principalSchema: "application",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_educations_education_id",
                        column: x => x.education_id,
                        principalSchema: "application",
                        principalTable: "educations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_info_currencies_currency_id",
                        column: x => x.currency_id,
                        principalSchema: "info",
                        principalTable: "info_currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_info_professions_profession_id",
                        column: x => x.profession_id,
                        principalSchema: "info",
                        principalTable: "info_professions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_info_skills_skill_id",
                        column: x => x.skill_id,
                        principalSchema: "info",
                        principalTable: "info_skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_info_types_of_employment_type_of_employment_id",
                        column: x => x.type_of_employment_id,
                        principalSchema: "info",
                        principalTable: "info_types_of_employment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_info_working_hours_working_hour_id",
                        column: x => x.working_hour_id,
                        principalSchema: "info",
                        principalTable: "info_working_hours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resumes_work_experiences_work_experiance_id",
                        column: x => x.work_experiance_id,
                        principalSchema: "application",
                        principalTable: "work_experiences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "replies",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacancy_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_replies", x => x.id);
                    table.ForeignKey(
                        name: "FK_replies_users_employer_id",
                        column: x => x.employer_id,
                        principalSchema: "application",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_replies_vacancies_vacancy_id",
                        column: x => x.vacancy_id,
                        principalSchema: "application",
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companies_city_id",
                schema: "application",
                table: "companies",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_contents_user_id",
                schema: "application",
                table: "contents",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_educations_level_id",
                schema: "application",
                table: "educations",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_info_skills_level_id",
                schema: "info",
                table: "info_skills",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_replies_employer_id",
                schema: "application",
                table: "replies",
                column: "employer_id");

            migrationBuilder.CreateIndex(
                name: "IX_replies_vacancy_id",
                schema: "application",
                table: "replies",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_contact_id",
                schema: "application",
                table: "resumes",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_currency_id",
                schema: "application",
                table: "resumes",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_education_id",
                schema: "application",
                table: "resumes",
                column: "education_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_profession_id",
                schema: "application",
                table: "resumes",
                column: "profession_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_skill_id",
                schema: "application",
                table: "resumes",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_type_of_employment_id",
                schema: "application",
                table: "resumes",
                column: "type_of_employment_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_user_id",
                schema: "application",
                table: "resumes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_work_experiance_id",
                schema: "application",
                table: "resumes",
                column: "work_experiance_id");

            migrationBuilder.CreateIndex(
                name: "IX_resumes_working_hour_id",
                schema: "application",
                table: "resumes",
                column: "working_hour_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_city_id",
                schema: "application",
                table: "users",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_language_id",
                schema: "application",
                table: "users",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_language_level_id",
                schema: "application",
                table: "users",
                column: "language_level_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                schema: "application",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_status_id",
                schema: "application",
                table: "users",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacancies_company_id",
                schema: "application",
                table: "vacancies",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacancies_profession_id",
                schema: "application",
                table: "vacancies",
                column: "profession_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacancies_type_of_employment",
                schema: "application",
                table: "vacancies",
                column: "type_of_employment");

            migrationBuilder.CreateIndex(
                name: "IX_vacancies_working_hour_id",
                schema: "application",
                table: "vacancies",
                column: "working_hour_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contents",
                schema: "application");

            migrationBuilder.DropTable(
                name: "logs",
                schema: "application");

            migrationBuilder.DropTable(
                name: "otps",
                schema: "application");

            migrationBuilder.DropTable(
                name: "replies",
                schema: "application");

            migrationBuilder.DropTable(
                name: "resumes",
                schema: "application");

            migrationBuilder.DropTable(
                name: "vacancies",
                schema: "application");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "application");

            migrationBuilder.DropTable(
                name: "educations",
                schema: "application");

            migrationBuilder.DropTable(
                name: "info_currencies",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_skills",
                schema: "info");

            migrationBuilder.DropTable(
                name: "users",
                schema: "application");

            migrationBuilder.DropTable(
                name: "work_experiences",
                schema: "application");

            migrationBuilder.DropTable(
                name: "companies",
                schema: "application");

            migrationBuilder.DropTable(
                name: "info_professions",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_types_of_employment",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_working_hours",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_languages",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_levels",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_roles",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_statuses",
                schema: "info");

            migrationBuilder.DropTable(
                name: "info_cities",
                schema: "info");
        }
    }
}
