using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class _25_12_2023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BwBookingForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCheckin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCheckout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingOnBehalf = table.Column<int>(type: "int", nullable: false),
                    SpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwBookingForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BwContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BwCustomerLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountRatio = table.Column<double>(type: "float", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwCustomerLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BwEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    FulName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BwHotelategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    HotelCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwHotelategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BwHotelUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwHotelUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BwLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationInfor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BwCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    IdCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerLevelId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwCustomer_BwCustomerLevel_CustomerLevelId",
                        column: x => x.CustomerLevelId,
                        principalTable: "BwCustomerLevel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BwBookingPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CheckInfor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breakfast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checkin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checkout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildrenPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubBedPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelUnitId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwBookingPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwBookingPolicy_BwHotelUnit_HotelUnitId",
                        column: x => x.HotelUnitId,
                        principalTable: "BwHotelUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BwHotelService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelUnitId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwHotelService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwHotelService_BwHotelUnit_HotelUnitId",
                        column: x => x.HotelUnitId,
                        principalTable: "BwHotelUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BwRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingCount = table.Column<int>(type: "int", nullable: false),
                    AverageVotePoint = table.Column<double>(type: "float", nullable: false),
                    AverageVoteStar = table.Column<double>(type: "float", nullable: false),
                    HotelUnitId = table.Column<int>(type: "int", nullable: true),
                    RoomCategoryId = table.Column<int>(type: "int", nullable: true),
                    HotelCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwRoom_BwHotelUnit_HotelUnitId",
                        column: x => x.HotelUnitId,
                        principalTable: "BwHotelUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BwRoom_BwHotelategory_HotelCategoryId",
                        column: x => x.HotelCategoryId,
                        principalTable: "BwHotelategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BwRoomCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    RoomCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRoomCount = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    EmptyRoomCount = table.Column<int>(type: "int", nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomCategoryService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    ServiceExtendPrice = table.Column<double>(type: "float", nullable: false),
                    FreeCancelBook = table.Column<bool>(type: "bit", nullable: false),
                    CancelBookFee = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    SpecialDiscount = table.Column<double>(type: "float", nullable: false),
                    HotelUnitId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwRoomCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwRoomCategory_BwHotelUnit_HotelUnitId",
                        column: x => x.HotelUnitId,
                        principalTable: "BwHotelUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BwBookingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomStateId = table.Column<int>(type: "int", nullable: false),
                    Checkin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checkout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdultCount = table.Column<int>(type: "int", nullable: false),
                    ChildrenCount = table.Column<int>(type: "int", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    OverstayFee = table.Column<double>(type: "float", nullable: false),
                    DateCancel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelFee = table.Column<double>(type: "float", nullable: false),
                    TotalBill = table.Column<double>(type: "float", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomCategoryId = table.Column<int>(type: "int", nullable: false),
                    BookingBillId = table.Column<int>(type: "int", nullable: false),
                    BookingFormId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwBookingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwBookingDetail_BwBookingForm_BookingFormId",
                        column: x => x.BookingFormId,
                        principalTable: "BwBookingForm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BwBookingDetail_BwRoom_RoomId",
                        column: x => x.RoomId,
                        principalTable: "BwRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BwHotelImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwHotelImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwHotelImg_BwRoom_RoomId",
                        column: x => x.RoomId,
                        principalTable: "BwRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BwRoomService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwRoomService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwRoomService_BwRoomCategory_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalTable: "BwRoomCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BwFeedbackVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VotePoint = table.Column<float>(type: "real", nullable: false),
                    VoteStar = table.Column<float>(type: "real", nullable: false),
                    BookingDetailId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BwFeedbackVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BwFeedbackVote_BwBookingDetail_BookingDetailId",
                        column: x => x.BookingDetailId,
                        principalTable: "BwBookingDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BwBookingDetail_BookingFormId",
                table: "BwBookingDetail",
                column: "BookingFormId");

            migrationBuilder.CreateIndex(
                name: "IX_BwBookingDetail_RoomId",
                table: "BwBookingDetail",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BwBookingPolicy_HotelUnitId",
                table: "BwBookingPolicy",
                column: "HotelUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BwCustomer_CustomerLevelId",
                table: "BwCustomer",
                column: "CustomerLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_BwFeedbackVote_BookingDetailId",
                table: "BwFeedbackVote",
                column: "BookingDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BwHotelImg_RoomId",
                table: "BwHotelImg",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BwHotelService_HotelUnitId",
                table: "BwHotelService",
                column: "HotelUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BwRoom_HotelCategoryId",
                table: "BwRoom",
                column: "HotelCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BwRoom_HotelUnitId",
                table: "BwRoom",
                column: "HotelUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BwRoomCategory_HotelUnitId",
                table: "BwRoomCategory",
                column: "HotelUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BwRoomService_RoomCategoryId",
                table: "BwRoomService",
                column: "RoomCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BwBookingPolicy");

            migrationBuilder.DropTable(
                name: "BwContact");

            migrationBuilder.DropTable(
                name: "BwCustomer");

            migrationBuilder.DropTable(
                name: "BwEmployee");

            migrationBuilder.DropTable(
                name: "BwFeedbackVote");

            migrationBuilder.DropTable(
                name: "BwHotelImg");

            migrationBuilder.DropTable(
                name: "BwHotelService");

            migrationBuilder.DropTable(
                name: "BwLocation");

            migrationBuilder.DropTable(
                name: "BwRoomService");

            migrationBuilder.DropTable(
                name: "BwCustomerLevel");

            migrationBuilder.DropTable(
                name: "BwBookingDetail");

            migrationBuilder.DropTable(
                name: "BwRoomCategory");

            migrationBuilder.DropTable(
                name: "BwBookingForm");

            migrationBuilder.DropTable(
                name: "BwRoom");

            migrationBuilder.DropTable(
                name: "BwHotelUnit");

            migrationBuilder.DropTable(
                name: "BwHotelategory");
        }
    }
}
