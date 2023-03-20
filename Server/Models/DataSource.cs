using BlazorSchedulerCrud.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSchedulerCrud.Server.Models
{
    public static class DataSource
    {
        private static IList<Appointment> _eventsData { get; set; }

        public static IList<Appointment> GetEvents()
        {
            if (_eventsData != null)
            {
                return _eventsData;
            }

            _eventsData = new List<Appointment>();

            Appointment events = new Appointment
            {
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                Location = "Space Centre USA",
                StartTime = new DateTime(2023, 1, 5, 9, 30, 0),
                EndTime = new DateTime(2023, 1, 5, 11, 0, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                Location = "Newyork City",
                StartTime = new DateTime(2023, 1, 6, 12, 0, 0),
                EndTime = new DateTime(2023, 1, 6, 14, 0, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                Location = "Space Centre USA",
                StartTime = new DateTime(2023, 1, 7, 9, 30, 0),
                EndTime = new DateTime(2023, 1, 7, 11, 0, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 4,
                Subject = "Meteor Showers in 2018",
                Location = "Space Centre USA",
                StartTime = new DateTime(2023, 1, 8, 13, 0, 0),
                EndTime = new DateTime(2023, 1, 8, 14, 30, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                Location = "Space Centre USA",
                StartTime = new DateTime(2023, 1, 9, 12, 0, 0),
                EndTime = new DateTime(2023, 1, 9, 14, 0, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 6,
                Subject = "Mysteries of Bermuda Triangle",
                Location = "Bermuda",
                StartTime = new DateTime(2023, 1, 9, 9, 30, 0),
                EndTime = new DateTime(2023, 1, 9, 11, 0, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 7,
                Subject = "Glaciers and Snowflakes",
                Location = "Himalayas",
                StartTime = new DateTime(2023, 1, 10, 11, 0, 0),
                EndTime = new DateTime(2023, 1, 10, 12, 30, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 8,
                Subject = "Life on Mars",
                Location = "Space Centre USA",
                StartTime = new DateTime(2023, 1, 11, 9, 0, 0),
                EndTime = new DateTime(2023, 1, 11, 10, 0, 0)
            };
            _eventsData.Add(events);

            events = new Appointment
            {
                Id = 9,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(2023, 1, 13, 11, 0, 0),
                EndTime = new DateTime(2023, 1, 13, 13, 0, 0)
            };
            _eventsData.Add(events);

            return _eventsData;
        }
    }
}
