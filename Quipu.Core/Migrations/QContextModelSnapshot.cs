﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quipu.Core.DAL;

namespace Quipu.Core.Migrations
{
    [DbContext(typeof(QContext))]
    partial class QContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<int>("MembersID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsID")
                        .HasColumnType("int");

                    b.HasKey("MembersID", "ProjectsID");

                    b.HasIndex("ProjectsID");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Alert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlertedUserID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Prioritized")
                        .HasColumnType("bit");

                    b.Property<int?>("RecordID")
                        .HasColumnType("int");

                    b.Property<int?>("TaskID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.Property<bool>("Viewed")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AlertedUserID");

                    b.HasIndex("TaskID");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Change", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssociatedField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecordID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Discussion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Posted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Discussion_Parent_ID")
                        .HasColumnType("int");

                    b.Property<string>("Message_Contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("Record_ID")
                        .HasColumnType("int");

                    b.Property<int?>("TaskID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.HasIndex("TaskID");

                    b.HasIndex("UserID");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Permission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Default")
                        .HasColumnType("bit");

                    b.Property<int>("Header_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PermissionHeaderID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PermissionHeaderID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.PermissionGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PermissionGroups");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.PriorityType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PriorityType");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PriorityID")
                        .HasColumnType("int");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PriorityID");

                    b.HasIndex("StatusID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Settings", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ID");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.StatusType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StatusType");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedToUserID")
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityID")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("StatusCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AssignedToUserID");

                    b.HasIndex("PriorityID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("StatusCategoryID");

                    b.HasIndex("StatusID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.TaskStatusCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TaskStatusCategory");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.TeamMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatorID")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamMessages");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Display_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.UserPermissionOverride", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Allow")
                        .HasColumnType("bit");

                    b.Property<int?>("PermissionID")
                        .HasColumnType("int");

                    b.Property<int>("Permission_ID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PermissionID");

                    b.HasIndex("UserID");

                    b.ToTable("UserPermissionOverrides");
                });

            modelBuilder.Entity("TeamUser", b =>
                {
                    b.Property<int>("MembersID")
                        .HasColumnType("int");

                    b.Property<int>("TeamsID")
                        .HasColumnType("int");

                    b.HasKey("MembersID", "TeamsID");

                    b.HasIndex("TeamsID");

                    b.ToTable("TeamUser");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.User", null)
                        .WithMany()
                        .HasForeignKey("MembersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quipu.Core.DomainModel.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Alert", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.User", "AlertedUser")
                        .WithMany("Alerts")
                        .HasForeignKey("AlertedUserID");

                    b.HasOne("Quipu.Core.DomainModel.Task", null)
                        .WithMany("Alerts")
                        .HasForeignKey("TaskID");

                    b.Navigation("AlertedUser");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Change", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.User", "UserWhoMadeChange")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserWhoMadeChange");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Discussion", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.Discussion", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentID");

                    b.HasOne("Quipu.Core.DomainModel.Task", null)
                        .WithMany("Discussions")
                        .HasForeignKey("TaskID");

                    b.HasOne("Quipu.Core.DomainModel.User", "User")
                        .WithMany("Discussions")
                        .HasForeignKey("UserID");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Permission", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.PermissionGroup", "PermissionHeader")
                        .WithMany("SecPermissions")
                        .HasForeignKey("PermissionHeaderID");

                    b.Navigation("PermissionHeader");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Project", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.PriorityType", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityID");

                    b.HasOne("Quipu.Core.DomainModel.StatusType", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID");

                    b.Navigation("Priority");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Task", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.User", "AssignedToUser")
                        .WithMany("TasksAssigned")
                        .HasForeignKey("AssignedToUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quipu.Core.DomainModel.PriorityType", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quipu.Core.DomainModel.Project", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectID");

                    b.HasOne("Quipu.Core.DomainModel.TaskStatusCategory", "StatusCategory")
                        .WithMany("Tasks")
                        .HasForeignKey("StatusCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quipu.Core.DomainModel.StatusType", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedToUser");

                    b.Navigation("Priority");

                    b.Navigation("Status");

                    b.Navigation("StatusCategory");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.TeamMessage", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorID");

                    b.HasOne("Quipu.Core.DomainModel.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID");

                    b.HasOne("Quipu.Core.DomainModel.Team", null)
                        .WithMany("Messages")
                        .HasForeignKey("TeamID");

                    b.Navigation("Creator");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.UserPermissionOverride", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.Permission", "Permission")
                        .WithMany("UserPermissionOverrides")
                        .HasForeignKey("PermissionID");

                    b.HasOne("Quipu.Core.DomainModel.User", "User")
                        .WithMany("UserPermissionOverrides")
                        .HasForeignKey("UserID");

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeamUser", b =>
                {
                    b.HasOne("Quipu.Core.DomainModel.User", null)
                        .WithMany()
                        .HasForeignKey("MembersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quipu.Core.DomainModel.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Discussion", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Permission", b =>
                {
                    b.Navigation("UserPermissionOverrides");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.PermissionGroup", b =>
                {
                    b.Navigation("SecPermissions");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Task", b =>
                {
                    b.Navigation("Alerts");

                    b.Navigation("Discussions");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.TaskStatusCategory", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.Team", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Quipu.Core.DomainModel.User", b =>
                {
                    b.Navigation("Alerts");

                    b.Navigation("Discussions");

                    b.Navigation("TasksAssigned");

                    b.Navigation("UserPermissionOverrides");
                });
#pragma warning restore 612, 618
        }
    }
}
