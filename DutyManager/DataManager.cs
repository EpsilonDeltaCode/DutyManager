using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataBaseConnection;
using DutyFramework.Implementations;
using DutyFramework.Interfaces;
using DutyManager.ViewModel;

namespace DutyManager
{
    public class DataManager
    {

        public DataManager(MainViewModel mainViewModel)
        {
            CurrentMainViewModel = mainViewModel;
            CurrentDataBaseManager = new DataBaseManager("TestDataBase");
        }

        public MainViewModel CurrentMainViewModel { get; set; }

        public DataBaseManager CurrentDataBaseManager { get; set; }

        public void Setup()
        {
            for (int i = 0; i < 3; i++)
            {
                Duty dutyA = new Duty()
                {
                    Titel = "TestDuty - Lauf3 - " + i,
                    Connections = new List<IDutyConnection>(),
                    Created = DateTime.Now,
                    Progress = 22,
                    ProgressDescription = "TestDutyStatusDescription1",
                    DeadLine = DateTime.MaxValue,
                    Id = Guid.NewGuid(),
                    LastChange = DateTime.Now,
                    Reminders = new List<IReminder>(),
                    Statements = new List<IStatement>()
                };

                CurrentDataBaseManager.TryAddDutyToDataBase(dutyA);
            }

            CurrentMainViewModel.MainDutyList = CurrentDataBaseManager.GenerateFullDutyList();
        }
    }
}
