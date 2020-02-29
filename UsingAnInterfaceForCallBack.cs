using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

class Program
{
    //Callback using an interface IMeeting. ShowAgenda is the only method invoked from the interface
    public interface IMeeting
    {
        void ShowAgenda(string agenda);
        void EmployeeAttendMeeting(string employee);
        void EmployeeLeftMeeting(string employee);
    }

    public class Meeting : IMeeting
    {
        public void EmployeeAttendMeeting(string employee)
        {
            Console.WriteLine($"Employee Attended Meeting: { employee }");
        }

        public void EmployeeLeftMeeting(string employee)
        {
            Console.WriteLine($"Employee Left Meeting: { employee }");
        }

        public void ShowAgenda(string agenda)
        {
            Console.WriteLine("Agenda Details: " + agenda);
        }
    }

    public class MeetingRoom
    {
        private string _message;

        public MeetingRoom(string message)
        {
            _message = message;
        }

        public void StartMeeting(IMeeting meeting)
        {
            //Callback
            if (meeting != null)
            {
                meeting.ShowAgenda(_message);
            }
        }
    }

    public class MeetingExecution
    {
        public void PerformMeeting()
        {
            IMeeting meeting = new Meeting();
            MeetingRoom meetingStarted = new MeetingRoom("Code Quality Improvement Meeting");
            meetingStarted.StartMeeting(meeting);
        }
    }

    static void Main()
    {
        MeetingExecution meetingExecution = new MeetingExecution();
        meetingExecution.PerformMeeting();
        Console.ReadLine();
    }
}