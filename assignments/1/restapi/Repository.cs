using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Microsoft.Extensions.Caching.Distributed;
using restapi.Models;

namespace restapi
{
    public class TimesheetsRepository
    {
        const string DATABASE_FILE = "filename=timesheets.db;mode=exclusive";

        static TimesheetsRepository()
        {
            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var timesheets = database.GetCollection<Timecard>("timesheets");

                timesheets.EnsureIndex(t => t.UniqueIdentifier);
            }
        }


        public IEnumerable<Timecard> All
        {
            get
            {
                using (var database = new LiteDatabase(DATABASE_FILE))
                {
                    var timesheets = database.GetCollection<Timecard>("timesheets");

                    return timesheets.Find(Query.All()).ToList();
                }
            }
        }

        public Timecard Find(Guid id)
        {
            Timecard timecard = null;

            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var timesheets = database.GetCollection<Timecard>("timesheets");

                timecard = timesheets
                    .FindOne(t => t.UniqueIdentifier == id);
            }

            return timecard;
        }

        public void Add(Timecard timecard)
        {
            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var timesheets = database.GetCollection<Timecard>("timesheets");

                timesheets.Insert(timecard);
            }
        }

        public void Update(Timecard timecard)
        {
            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var timesheets = database.GetCollection<Timecard>("timesheets");

                timesheets.Update(timecard);
            }
        }

        public void Delete(Guid id)
        {
            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var timesheets = database.GetCollection<Timecard>("timesheets");

                timesheets.Delete(t => t.UniqueIdentifier == id);
            }
        }
    }

    public class PeopleRepository
    {
        const string DATABASE_FILE = "filename=people.db;mode=exclusive";

        static PeopleRepository()
        {
            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var people = database.GetCollection<People>("people");

                people.EnsureIndex(t => t.UniqueIdentifier);
            }
        }


        public IEnumerable<People> All
        {
            get
            {
                using (var database = new LiteDatabase(DATABASE_FILE))
                {
                    var allPeople = database.GetCollection<People>("people");

                    return allPeople.Find(Query.All()).ToList();
                }
            }
        }

        public People Find(int id)
        {
            People people = null;

            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var allPeople = database.GetCollection<People>("people");

                people = allPeople
                    .FindOne(t => t.Id == id);
            }

            return people;
        }

        public void Add(People people)
        {
            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var allPeople = database.GetCollection<People>("people");

                allPeople.Insert(people);
            }
        }

        public void Update(People people)
        {
            using (var database = new LiteDatabase(DATABASE_FILE))
            {
                var allPeople = database.GetCollection<People>("people");

                allPeople.Update(people);
            }
        }

        // public void Delete(Guid id)
        // {
        //     using (var database = new LiteDatabase(DATABASE_FILE))
        //     {
        //         var allPeople = database.GetCollection<People>("people");

        //         allPeople.Delete(t => t.UniqueIdentifier == id);
        //     }
        // }
    }
}