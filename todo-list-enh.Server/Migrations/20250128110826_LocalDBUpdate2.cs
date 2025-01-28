using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_list_enh.Server.Migrations
{
    /// <inheritdoc />
    public partial class LocalDBUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyGoals_Days_DayId",
                table: "DailyGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyGoals_Goals_GoalId",
                table: "DailyGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyTasks_Days_DayId",
                table: "DailyTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyTasks_Tasks_TaskId",
                table: "DailyTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_User_UserId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_User_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalRecords_Journals_JournalId",
                table: "JournalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_User_UserId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_UserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekGoals_Goals_GoalId",
                table: "WeekGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekGoals_Weeks_WeekId",
                table: "WeekGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_Weeks_User_UserId",
                table: "Weeks");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekTasks_Tasks_TaskId",
                table: "WeekTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekTasks_Weeks_WeekId",
                table: "WeekTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekTasks",
                table: "WeekTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weeks",
                table: "Weeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekGoals",
                table: "WeekGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journals",
                table: "Journals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalRecords",
                table: "JournalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyTasks",
                table: "DailyTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyGoals",
                table: "DailyGoals");

            migrationBuilder.RenameTable(
                name: "WeekTasks",
                newName: "WeekTask");

            migrationBuilder.RenameTable(
                name: "Weeks",
                newName: "Week");

            migrationBuilder.RenameTable(
                name: "WeekGoals",
                newName: "WeekGoal");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "Journals",
                newName: "Journal");

            migrationBuilder.RenameTable(
                name: "JournalRecords",
                newName: "JournalRecord");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goal");

            migrationBuilder.RenameTable(
                name: "Days",
                newName: "Day");

            migrationBuilder.RenameTable(
                name: "DailyTasks",
                newName: "DailyTask");

            migrationBuilder.RenameTable(
                name: "DailyGoals",
                newName: "DailyGoal");

            migrationBuilder.RenameIndex(
                name: "IX_WeekTasks_WeekId",
                table: "WeekTask",
                newName: "IX_WeekTask_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekTasks_TaskId",
                table: "WeekTask",
                newName: "IX_WeekTask_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Weeks_UserId",
                table: "Week",
                newName: "IX_Week_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekGoals_WeekId",
                table: "WeekGoal",
                newName: "IX_WeekGoal_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekGoals_GoalId",
                table: "WeekGoal",
                newName: "IX_WeekGoal_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UserId",
                table: "Task",
                newName: "IX_Task_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Journals_UserId",
                table: "Journal",
                newName: "IX_Journal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalRecords_JournalId",
                table: "JournalRecord",
                newName: "IX_JournalRecord_JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_UserId",
                table: "Goal",
                newName: "IX_Goal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Days_UserId",
                table: "Day",
                newName: "IX_Day_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyTasks_TaskId",
                table: "DailyTask",
                newName: "IX_DailyTask_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyTasks_DayId",
                table: "DailyTask",
                newName: "IX_DailyTask_DayId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyGoals_GoalId",
                table: "DailyGoal",
                newName: "IX_DailyGoal_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyGoals_DayId",
                table: "DailyGoal",
                newName: "IX_DailyGoal_DayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekTask",
                table: "WeekTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Week",
                table: "Week",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekGoal",
                table: "WeekGoal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journal",
                table: "Journal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalRecord",
                table: "JournalRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goal",
                table: "Goal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Day",
                table: "Day",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyTask",
                table: "DailyTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyGoal",
                table: "DailyGoal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyGoal_Day_DayId",
                table: "DailyGoal",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyGoal_Goal_GoalId",
                table: "DailyGoal",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTask_Day_DayId",
                table: "DailyTask",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTask_Task_TaskId",
                table: "DailyTask",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_User_UserId",
                table: "Day",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_User_UserId",
                table: "Goal",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journal_User_UserId",
                table: "Journal",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalRecord_Journal_JournalId",
                table: "JournalRecord",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_UserId",
                table: "Task",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Week_User_UserId",
                table: "Week",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekGoal_Goal_GoalId",
                table: "WeekGoal",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekGoal_Week_WeekId",
                table: "WeekGoal",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekTask_Task_TaskId",
                table: "WeekTask",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekTask_Week_WeekId",
                table: "WeekTask",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyGoal_Day_DayId",
                table: "DailyGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyGoal_Goal_GoalId",
                table: "DailyGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyTask_Day_DayId",
                table: "DailyTask");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyTask_Task_TaskId",
                table: "DailyTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Day_User_UserId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_User_UserId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Journal_User_UserId",
                table: "Journal");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalRecord_Journal_JournalId",
                table: "JournalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_UserId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Week_User_UserId",
                table: "Week");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekGoal_Goal_GoalId",
                table: "WeekGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekGoal_Week_WeekId",
                table: "WeekGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekTask_Task_TaskId",
                table: "WeekTask");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekTask_Week_WeekId",
                table: "WeekTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekTask",
                table: "WeekTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekGoal",
                table: "WeekGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Week",
                table: "Week");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalRecord",
                table: "JournalRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journal",
                table: "Journal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goal",
                table: "Goal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Day",
                table: "Day");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyTask",
                table: "DailyTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyGoal",
                table: "DailyGoal");

            migrationBuilder.RenameTable(
                name: "WeekTask",
                newName: "WeekTasks");

            migrationBuilder.RenameTable(
                name: "WeekGoal",
                newName: "WeekGoals");

            migrationBuilder.RenameTable(
                name: "Week",
                newName: "Weeks");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "JournalRecord",
                newName: "JournalRecords");

            migrationBuilder.RenameTable(
                name: "Journal",
                newName: "Journals");

            migrationBuilder.RenameTable(
                name: "Goal",
                newName: "Goals");

            migrationBuilder.RenameTable(
                name: "Day",
                newName: "Days");

            migrationBuilder.RenameTable(
                name: "DailyTask",
                newName: "DailyTasks");

            migrationBuilder.RenameTable(
                name: "DailyGoal",
                newName: "DailyGoals");

            migrationBuilder.RenameIndex(
                name: "IX_WeekTask_WeekId",
                table: "WeekTasks",
                newName: "IX_WeekTasks_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekTask_TaskId",
                table: "WeekTasks",
                newName: "IX_WeekTasks_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekGoal_WeekId",
                table: "WeekGoals",
                newName: "IX_WeekGoals_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekGoal_GoalId",
                table: "WeekGoals",
                newName: "IX_WeekGoals_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Week_UserId",
                table: "Weeks",
                newName: "IX_Weeks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UserId",
                table: "Tasks",
                newName: "IX_Tasks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalRecord_JournalId",
                table: "JournalRecords",
                newName: "IX_JournalRecords_JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_Journal_UserId",
                table: "Journals",
                newName: "IX_Journals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_UserId",
                table: "Goals",
                newName: "IX_Goals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Day_UserId",
                table: "Days",
                newName: "IX_Days_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyTask_TaskId",
                table: "DailyTasks",
                newName: "IX_DailyTasks_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyTask_DayId",
                table: "DailyTasks",
                newName: "IX_DailyTasks_DayId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyGoal_GoalId",
                table: "DailyGoals",
                newName: "IX_DailyGoals_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyGoal_DayId",
                table: "DailyGoals",
                newName: "IX_DailyGoals_DayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekTasks",
                table: "WeekTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekGoals",
                table: "WeekGoals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weeks",
                table: "Weeks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalRecords",
                table: "JournalRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journals",
                table: "Journals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyTasks",
                table: "DailyTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyGoals",
                table: "DailyGoals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyGoals_Days_DayId",
                table: "DailyGoals",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyGoals_Goals_GoalId",
                table: "DailyGoals",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTasks_Days_DayId",
                table: "DailyTasks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTasks_Tasks_TaskId",
                table: "DailyTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_User_UserId",
                table: "Days",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_User_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalRecords_Journals_JournalId",
                table: "JournalRecords",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_User_UserId",
                table: "Journals",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekGoals_Goals_GoalId",
                table: "WeekGoals",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekGoals_Weeks_WeekId",
                table: "WeekGoals",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weeks_User_UserId",
                table: "Weeks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekTasks_Tasks_TaskId",
                table: "WeekTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekTasks_Weeks_WeekId",
                table: "WeekTasks",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
