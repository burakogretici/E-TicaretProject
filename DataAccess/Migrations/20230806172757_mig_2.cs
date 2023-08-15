using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("032b946f-1d38-4112-8ed7-7f0158172ab3"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("11509f91-4565-4aa5-8fdf-b9f49e926070"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("230fb01e-63f1-4277-90b0-49840692ee43"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("28abba63-e13c-44b6-a456-80c8ea6d1d98"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3d8bd3c7-c69f-47a8-a2cd-147c8bebe973"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("cb952095-738b-47f0-9116-d9600ac73c41"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("14fbaa49-447d-4aa7-8123-4869c0c30657"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b23282f-3972-4664-a7d7-448e262c0234"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4b97a2fb-981c-4e29-8c53-02593a423960"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6e7447e4-4a7e-4426-b889-a24891c63ff0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74c249d0-d87c-4e93-be40-ed0354862633"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ebe20209-7a42-4f55-94c8-7a89b7a8efc0"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("03d7411f-913a-4da8-be1a-197c9b4f248d"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("067931fc-537f-4e7b-9305-3f565fdcd60c"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("06bc3dbd-6c76-4808-b985-85d98a161b40"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("082ca3e7-3936-4b19-8eca-499e176b16d3"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0c158e18-ad15-48db-be13-bd0f775a6b47"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0cefc923-39e9-440c-959c-f3c3c80697f9"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("14ecf694-e452-43e8-811d-729619db671c"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("151e6602-b5c8-4ac2-a8d8-6c39b6f29cfe"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1a862cbe-8b80-4ec2-8819-160c15aeb442"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("22b2443a-c2a5-48be-a7bd-25fb3f0ed13f"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("25641ea9-4daa-41cf-8f42-fccd346dbeca"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2740c546-d2f5-4c04-a6b8-8a686567e994"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2b5f6a24-c069-4342-96da-f45f1a63c38c"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2bbd342d-0f97-4b2f-a771-c78321effa91"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2efcd8a3-20ac-4d58-b92f-79900724910e"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4be15239-d493-4a77-b287-1cf479fd4c70"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5b742a1f-b307-4035-929e-589439ab5a24"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5f46690f-247b-4e47-a003-faa7356162e4"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("63b4f025-de87-4c9b-b878-b23eb3ddc4fc"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("686adafc-54f3-4138-94ba-cdc8a337a42b"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("68abc88b-8d5d-4042-b2a8-96fb5924daa2"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7bc72b1b-a7d3-4bb8-9498-a726cc38905c"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9185040a-83dc-41c6-98dc-f6c39e2955e4"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9534beb2-cc33-4da8-9bf5-dba9504cd4f4"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a4f6c971-87e9-450c-9bbe-d2ded3659fe1"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a9b47d69-4e60-4e1c-9397-a0d43fd20cdb"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("aa166960-6ccd-481b-a5d2-bb7d8c68aa0c"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ab2e9550-849c-4c0f-b216-a0176d8c4351"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b3881b21-ab0c-4dcb-9505-795c4d79e631"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b63cce88-a4b9-4eb0-b346-7c5726755b97"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b838adf0-9dd5-4d0d-b04d-09ee44173da9"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c2b7baff-ebd9-441f-9332-7869380d72ef"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c834bb7d-8a74-446a-969f-9723f3eac517"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ca5227d7-e561-43e6-ae04-6dfbbe8ae1bd"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ce39b985-63c3-40e6-a0f4-115b72f07a3a"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d5cae042-d87a-440b-9873-7418a27c9b92"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d5cf0cad-af7b-4c7c-a5c7-87f96eb9175b"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e3599b3b-e04d-4d79-8ca3-7d7f141fe569"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e453f0ca-8b2a-40e1-a305-ab8b54d270a4"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e60a5a5a-d3f0-4633-8f72-640f147d3f03"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e6ea34a2-37d3-409f-812d-94b5e28b46cc"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e8cb5736-bcb8-4c1d-aedb-fa60723abfcc"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("eb985034-e99b-4375-a891-42fb6a5bb34b"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f2e48ba2-c89c-4013-a34a-3e27130e423e"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("feb0551c-2b88-4967-aa5b-627da8c4c030"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ff1118ab-3d33-4c02-bdc1-a4407b797df5"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7bea26bf-ceec-4e6f-9f66-9d67ffd60bf2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İphone", null },
                    { new Guid("e835a5fd-74e7-488a-a840-ddce2755e7f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Samsung", null },
                    { new Guid("f8845ea1-f085-42fc-a851-72e1761c0f23"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Vestel", null },
                    { new Guid("7f692f3a-1177-48f5-8e03-ae238ab3cda8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Asus", null },
                    { new Guid("8ab10fd3-6e04-42d7-ab8d-81b5c4bec33b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Philips", null },
                    { new Guid("efe24598-d27e-4e6c-ba86-0efac1a2ad68"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Hp", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6efc50a3-0926-4d3b-8f7c-f88b50b10082"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mobilya", null },
                    { new Guid("4e9be0d0-dd4d-440f-a2c4-eceaabf19f6b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Beyaz Eşya", null },
                    { new Guid("4a51d8d8-f034-48a8-b4b9-c3f5c5a48a9d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Giyim", null },
                    { new Guid("58526241-fef9-4ed9-bdab-99cc68e02193"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Elektronik", null },
                    { new Guid("4d94f442-b948-43fc-8fec-6d9e0014c3ce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Telefon", null },
                    { new Guid("0a981a18-e6d3-4879-a971-22659552cb32"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bilgisayar", null }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "/product/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "/brand/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "/category/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "/color/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "Url",
                value: "/order/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "Url",
                value: "/adress/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "Url",
                value: "/country/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "Url",
                value: "/city/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "Url",
                value: "/user/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "Url",
                value: "/operationclaim/index");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "Url",
                value: "/useroperationclaim/index");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("838d948d-4652-4b46-a844-dcd0f53fb6c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Add", null },
                    { new Guid("29a7e6ca-fd12-4fe0-9e5e-e7dfb1c5a822"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Add", null },
                    { new Guid("2f967ac0-723d-483d-a9a1-7a6b61043cf4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.List", null },
                    { new Guid("7b281c3d-e19a-4f49-9fef-b61c31687953"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Delete", null },
                    { new Guid("8cbc840f-3c8d-4e48-ba50-0a6b5b7dc4cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Update", null },
                    { new Guid("75195646-f45b-4242-b7c1-a50c9b82473f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Get", null },
                    { new Guid("3074de5e-ef15-466c-a481-8dc109b98103"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Add", null },
                    { new Guid("c8eb87dc-1007-4226-9b58-b5fe9f3d70b0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.List", null },
                    { new Guid("3eb7f188-f44c-4336-8b97-a306ed357d60"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Delete", null },
                    { new Guid("6379ee1f-175d-4deb-a072-83fdf2b85713"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Update", null },
                    { new Guid("d2176c11-93ae-4476-a4df-55691dd88350"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Get", null },
                    { new Guid("1bc1eeab-0144-4963-bf78-9f711c8cea1f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Delete", null },
                    { new Guid("580e291a-ef64-4fbd-bebe-298f467b21fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.List", null },
                    { new Guid("bdf591cc-191e-4d98-b78b-f4afd15e7a87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Add", null },
                    { new Guid("a8ff9516-1e1b-496a-81a7-a5b2fa225ef5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Get", null },
                    { new Guid("7c97c838-04bf-4e1a-bab6-2559e83bc2d5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Update", null },
                    { new Guid("c32d5773-8a85-4679-8013-f0d88f4a98bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Delete", null },
                    { new Guid("7fd159bd-680f-4c0b-949c-602ffc28cad9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.List", null },
                    { new Guid("025a40f4-f11a-4422-b184-a9d7084bac0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Add", null }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a1252ad2-6519-4d38-8d48-3db4d8531dca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null },
                    { new Guid("c44166c3-cad1-4966-a426-46f732f412e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Get", null },
                    { new Guid("596e6bc7-6c5e-4ee8-8139-ab67b32d019d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Update", null },
                    { new Guid("af1fb35d-e090-4962-98b4-805e3470ed35"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Delete", null },
                    { new Guid("10a0b009-0ae9-4116-98f8-721ee66afd7f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.List", null },
                    { new Guid("d97ee25a-370c-4ce2-9087-80c0882c744e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.List", null },
                    { new Guid("02b8d7fd-9060-4c26-a6ae-1d5a688c23b0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Delete", null },
                    { new Guid("a0733478-e5d0-4dcd-84b7-324c9b0e69b9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Update", null },
                    { new Guid("be5e33f6-0f7d-4b73-9f35-d21a488db37e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Get", null },
                    { new Guid("18d57b5c-e0c6-4494-a0b6-0e4e0f3c3923"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Add", null },
                    { new Guid("ea7b041a-02da-4e35-90f0-f37bfe86cb35"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.List", null },
                    { new Guid("ba8b5011-64c1-4cbf-b3c7-00836d1d2458"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Delete", null },
                    { new Guid("bbae5fed-e6dc-4989-9b77-d5dc85a6c000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Update", null },
                    { new Guid("6af7ff3b-2f9e-450e-87d3-38e4cf268c85"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Get", null },
                    { new Guid("e74c43f0-382a-422c-968e-b44b49cb68e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Get", null },
                    { new Guid("ff3b32d7-ba43-436b-b7b2-964ce6c58cc0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Add", null },
                    { new Guid("cd9f8786-1fe5-4475-b922-fe2ee8334c45"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Delete", null },
                    { new Guid("0848fae2-9e22-4179-9780-72083c61dd6b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Update", null },
                    { new Guid("a01e95ca-ac62-4c55-adc1-b687fbbd5d2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Get", null },
                    { new Guid("07a3ed58-e8d0-4bb2-9aa8-dd48a95c8135"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Add", null },
                    { new Guid("64978ae0-4743-4fa5-a8c0-c80e8639342a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.List", null },
                    { new Guid("6b242b08-16c5-4249-b79a-ec3454e79232"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Delete", null },
                    { new Guid("2fc64b39-8ffe-408e-b2a9-4d80e24d9cf6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Update", null },
                    { new Guid("3c2390dc-ce4e-469a-b600-077ee4ee802a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Get", null },
                    { new Guid("13d1a812-b2b7-47f2-b94c-72ae32192fb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Add", null },
                    { new Guid("2077ac3e-f6fb-4a56-a5e4-7a0f6d67c9b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Update", null },
                    { new Guid("2ce30a08-f64c-4c6c-8af0-9881f17da8f0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.List", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7bea26bf-ceec-4e6f-9f66-9d67ffd60bf2"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7f692f3a-1177-48f5-8e03-ae238ab3cda8"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8ab10fd3-6e04-42d7-ab8d-81b5c4bec33b"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e835a5fd-74e7-488a-a840-ddce2755e7f8"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("efe24598-d27e-4e6c-ba86-0efac1a2ad68"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f8845ea1-f085-42fc-a851-72e1761c0f23"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a981a18-e6d3-4879-a971-22659552cb32"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4a51d8d8-f034-48a8-b4b9-c3f5c5a48a9d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d94f442-b948-43fc-8fec-6d9e0014c3ce"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4e9be0d0-dd4d-440f-a2c4-eceaabf19f6b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58526241-fef9-4ed9-bdab-99cc68e02193"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6efc50a3-0926-4d3b-8f7c-f88b50b10082"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("025a40f4-f11a-4422-b184-a9d7084bac0d"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("02b8d7fd-9060-4c26-a6ae-1d5a688c23b0"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("07a3ed58-e8d0-4bb2-9aa8-dd48a95c8135"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0848fae2-9e22-4179-9780-72083c61dd6b"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("10a0b009-0ae9-4116-98f8-721ee66afd7f"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("13d1a812-b2b7-47f2-b94c-72ae32192fb1"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("18d57b5c-e0c6-4494-a0b6-0e4e0f3c3923"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1bc1eeab-0144-4963-bf78-9f711c8cea1f"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2077ac3e-f6fb-4a56-a5e4-7a0f6d67c9b2"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("29a7e6ca-fd12-4fe0-9e5e-e7dfb1c5a822"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2ce30a08-f64c-4c6c-8af0-9881f17da8f0"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2f967ac0-723d-483d-a9a1-7a6b61043cf4"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2fc64b39-8ffe-408e-b2a9-4d80e24d9cf6"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3074de5e-ef15-466c-a481-8dc109b98103"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3c2390dc-ce4e-469a-b600-077ee4ee802a"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3eb7f188-f44c-4336-8b97-a306ed357d60"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("580e291a-ef64-4fbd-bebe-298f467b21fc"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("596e6bc7-6c5e-4ee8-8139-ab67b32d019d"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6379ee1f-175d-4deb-a072-83fdf2b85713"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("64978ae0-4743-4fa5-a8c0-c80e8639342a"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6af7ff3b-2f9e-450e-87d3-38e4cf268c85"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6b242b08-16c5-4249-b79a-ec3454e79232"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("75195646-f45b-4242-b7c1-a50c9b82473f"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7b281c3d-e19a-4f49-9fef-b61c31687953"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7c97c838-04bf-4e1a-bab6-2559e83bc2d5"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7fd159bd-680f-4c0b-949c-602ffc28cad9"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("838d948d-4652-4b46-a844-dcd0f53fb6c8"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8cbc840f-3c8d-4e48-ba50-0a6b5b7dc4cd"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a01e95ca-ac62-4c55-adc1-b687fbbd5d2e"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a0733478-e5d0-4dcd-84b7-324c9b0e69b9"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a1252ad2-6519-4d38-8d48-3db4d8531dca"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a8ff9516-1e1b-496a-81a7-a5b2fa225ef5"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("af1fb35d-e090-4962-98b4-805e3470ed35"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ba8b5011-64c1-4cbf-b3c7-00836d1d2458"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bbae5fed-e6dc-4989-9b77-d5dc85a6c000"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bdf591cc-191e-4d98-b78b-f4afd15e7a87"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("be5e33f6-0f7d-4b73-9f35-d21a488db37e"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c32d5773-8a85-4679-8013-f0d88f4a98bf"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c44166c3-cad1-4966-a426-46f732f412e7"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c8eb87dc-1007-4226-9b58-b5fe9f3d70b0"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("cd9f8786-1fe5-4475-b922-fe2ee8334c45"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2176c11-93ae-4476-a4df-55691dd88350"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d97ee25a-370c-4ce2-9087-80c0882c744e"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e74c43f0-382a-422c-968e-b44b49cb68e8"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ea7b041a-02da-4e35-90f0-f37bfe86cb35"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ff3b32d7-ba43-436b-b7b2-964ce6c58cc0"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("cb952095-738b-47f0-9116-d9600ac73c41"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İphone", null },
                    { new Guid("230fb01e-63f1-4277-90b0-49840692ee43"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Samsung", null },
                    { new Guid("3d8bd3c7-c69f-47a8-a2cd-147c8bebe973"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Vestel", null },
                    { new Guid("28abba63-e13c-44b6-a456-80c8ea6d1d98"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Asus", null },
                    { new Guid("11509f91-4565-4aa5-8fdf-b9f49e926070"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Philips", null },
                    { new Guid("032b946f-1d38-4112-8ed7-7f0158172ab3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Hp", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ebe20209-7a42-4f55-94c8-7a89b7a8efc0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mobilya", null },
                    { new Guid("74c249d0-d87c-4e93-be40-ed0354862633"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Beyaz Eşya", null },
                    { new Guid("4b97a2fb-981c-4e29-8c53-02593a423960"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Giyim", null },
                    { new Guid("14fbaa49-447d-4aa7-8123-4869c0c30657"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Elektronik", null },
                    { new Guid("6e7447e4-4a7e-4426-b889-a24891c63ff0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Telefon", null },
                    { new Guid("2b23282f-3972-4664-a7d7-448e262c0234"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bilgisayar", null }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "Url",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "Url",
                value: null);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4be15239-d493-4a77-b287-1cf479fd4c70"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Add", null },
                    { new Guid("ce39b985-63c3-40e6-a0f4-115b72f07a3a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Add", null },
                    { new Guid("ff1118ab-3d33-4c02-bdc1-a4407b797df5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.List", null },
                    { new Guid("7bc72b1b-a7d3-4bb8-9498-a726cc38905c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Delete", null },
                    { new Guid("2740c546-d2f5-4c04-a6b8-8a686567e994"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Update", null },
                    { new Guid("25641ea9-4daa-41cf-8f42-fccd346dbeca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OperationClaim.Get", null },
                    { new Guid("aa166960-6ccd-481b-a5d2-bb7d8c68aa0c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Add", null },
                    { new Guid("9185040a-83dc-41c6-98dc-f6c39e2955e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.List", null },
                    { new Guid("22b2443a-c2a5-48be-a7bd-25fb3f0ed13f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Delete", null },
                    { new Guid("686adafc-54f3-4138-94ba-cdc8a337a42b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Update", null },
                    { new Guid("d5cae042-d87a-440b-9873-7418a27c9b92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "UserOperationClaim.Get", null },
                    { new Guid("e8cb5736-bcb8-4c1d-aedb-fa60723abfcc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Delete", null },
                    { new Guid("b63cce88-a4b9-4eb0-b346-7c5726755b97"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.List", null },
                    { new Guid("b3881b21-ab0c-4dcb-9505-795c4d79e631"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Add", null },
                    { new Guid("067931fc-537f-4e7b-9305-3f565fdcd60c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Get", null },
                    { new Guid("68abc88b-8d5d-4042-b2a8-96fb5924daa2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Update", null },
                    { new Guid("b838adf0-9dd5-4d0d-b04d-09ee44173da9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Delete", null },
                    { new Guid("e453f0ca-8b2a-40e1-a305-ab8b54d270a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.List", null },
                    { new Guid("c2b7baff-ebd9-441f-9332-7869380d72ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Category.Add", null }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("e3599b3b-e04d-4d79-8ca3-7d7f141fe569"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null },
                    { new Guid("151e6602-b5c8-4ac2-a8d8-6c39b6f29cfe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Get", null },
                    { new Guid("082ca3e7-3936-4b19-8eca-499e176b16d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Update", null },
                    { new Guid("c834bb7d-8a74-446a-969f-9723f3eac517"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Delete", null },
                    { new Guid("0cefc923-39e9-440c-959c-f3c3c80697f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.List", null },
                    { new Guid("d5cf0cad-af7b-4c7c-a5c7-87f96eb9175b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.List", null },
                    { new Guid("ca5227d7-e561-43e6-ae04-6dfbbe8ae1bd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Delete", null },
                    { new Guid("06bc3dbd-6c76-4808-b985-85d98a161b40"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Update", null },
                    { new Guid("63b4f025-de87-4c9b-b878-b23eb3ddc4fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Color.Get", null },
                    { new Guid("eb985034-e99b-4375-a891-42fb6a5bb34b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Add", null },
                    { new Guid("5f46690f-247b-4e47-a003-faa7356162e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.List", null },
                    { new Guid("1a862cbe-8b80-4ec2-8819-160c15aeb442"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Delete", null },
                    { new Guid("2bbd342d-0f97-4b2f-a771-c78321effa91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Update", null },
                    { new Guid("a9b47d69-4e60-4e1c-9397-a0d43fd20cdb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Brand.Get", null },
                    { new Guid("f2e48ba2-c89c-4013-a34a-3e27130e423e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Get", null },
                    { new Guid("feb0551c-2b88-4967-aa5b-627da8c4c030"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Add", null },
                    { new Guid("a4f6c971-87e9-450c-9bbe-d2ded3659fe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Delete", null },
                    { new Guid("14ecf694-e452-43e8-811d-729619db671c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Update", null },
                    { new Guid("ab2e9550-849c-4c0f-b216-a0176d8c4351"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.Get", null },
                    { new Guid("03d7411f-913a-4da8-be1a-197c9b4f248d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Add", null },
                    { new Guid("2efcd8a3-20ac-4d58-b92f-79900724910e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.List", null },
                    { new Guid("0c158e18-ad15-48db-be13-bd0f775a6b47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Delete", null },
                    { new Guid("e60a5a5a-d3f0-4633-8f72-640f147d3f03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Update", null },
                    { new Guid("2b5f6a24-c069-4342-96da-f45f1a63c38c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Menu.Get", null },
                    { new Guid("e6ea34a2-37d3-409f-812d-94b5e28b46cc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "User.Add", null },
                    { new Guid("5b742a1f-b307-4035-929e-589439ab5a24"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Product.Update", null },
                    { new Guid("9534beb2-cc33-4da8-9bf5-dba9504cd4f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Address.List", null }
                });
        }
    }
}
