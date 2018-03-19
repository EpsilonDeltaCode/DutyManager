using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutyFramework.Implementations;
using DutyFramework.Interfaces;

namespace DataBaseConnection
{
    public class DataBaseManager
    {
        private readonly string _dataBaseName;

        public DataBaseManager(string dataBaseName)
        {
            _dataBaseName = dataBaseName;
        }

        public ObservableCollection<IDuty> GenerateFullDutyList()
        {
            ObservableCollection<IDuty> entries = new ObservableCollection<IDuty>();
            OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Connecting, null);
            using (var context = new DutyContext(_dataBaseName))
            {
                try
                {
                    var dataBaseEntries = from duty in context.Duties select duty;
                    foreach (Duty duty in dataBaseEntries)
                    {
                        entries.Add(duty);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.ElementNotFound, e);
                }

                OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Finished, null);
                return entries;
            }              
        }

        public Duty ReadDutyById(Guid id)
        {
            OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Connecting, null);
            using (var context = new DutyContext(_dataBaseName))
            {
                try
                {
                    Duty ret = context.Duties.First(duty => duty.Id == id);
                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Finished, null);
                    return ret;
                }
                catch (Exception e)
                {
                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.ElementNotFound, e);
                    Console.WriteLine(e);
                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Finished, null);
                    return null;
                }
            }
        }

        public bool TryAddDutyToDataBase(Duty duty)
        {
            bool succesful = false;
            OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Connecting, null);
            using (var context = new DutyContext(_dataBaseName))
            {
                try
                {
                    context.Duties.Add(duty);
                    context.SaveChanges();
                    succesful = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.ElementNotFound, e);
                }

                OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Finished, null);
                return succesful;
            }
        }


        public bool TryUpdateDuty(IDuty changedDuty)
        {
            Duty duty = null;
            bool successful = false;

            OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Connecting, null);
            using (var context = new DutyContext(_dataBaseName))
            {
                try
                {
                    duty = context.Duties.First(d => d.Id == changedDuty.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.ElementNotFound, e);
                }

                OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Finished, null);

                if (duty != null)
                {
                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Connecting, null);
                    try
                    {
                        context.Entry(duty).CurrentValues.SetValues(changedDuty);
                        context.SaveChanges();
                        successful = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.UpdateFailed, e);
                    }

                    OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag.Finished, null);
                }

                return successful;
            }
        }


        // Event creation when connection to database changes

        public delegate void DataBaseConnectionStatusEventHandler(object sender, DataBaseConnectionStatusEventArgs e);

        public event DataBaseConnectionStatusEventHandler DataBaseConnectionStatusEvents;

        private void OnDatBaseConnectionStatusChanged(DataBaseConnectionStatusFlag status, Exception failException)
        {
            Debug.WriteLine("DataBase Connection - Code:[" + status.ToString() + "]");
            DataBaseConnectionStatusEvents?.Invoke(this, new DataBaseConnectionStatusEventArgs(status, failException));
        }
    }
}
