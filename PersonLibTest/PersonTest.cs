using RhF.Model.PersonLib;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PersonLibTest
{
    public class PersonTest
    {
        static string firstname = "Firstname";
        static string lastname = "Lastname";


        [Fact]
        public void CreateEmptyConstructor_Passing()
        {
            Person p = new Person();

            Assert.NotNull(p);
        }

        [Fact]
        public void CreatefilledConstructor_Passing()
        {
            Person p = new Person(firstname, lastname);

            Assert.Equal(firstname, p.FirstName);
            Assert.Equal(lastname, p.LastName);
        }

        public static IEnumerable<object[]> FilledConst_Failing()
        {
            yield return new object[] { null, lastname, $"{nameof(Person)}:{nameof(Person.FirstName)}" };
            yield return new object[] { firstname, null, $"{nameof(Person)}:{nameof(Person.LastName)}" };
            yield return new object[] { string.Empty, lastname, $"{nameof(Person)}:{nameof(Person.FirstName)}" };
            yield return new object[] { firstname, string.Empty, $"{nameof(Person)}:{nameof(Person.LastName)}" };
            yield return new object[] { " ", lastname, $"{nameof(Person)}:{nameof(Person.FirstName)}" };
            yield return new object[] { firstname, " ", $"{nameof(Person)}:{nameof(Person.LastName)}" };
        }

        [Theory]
        [MemberData(nameof(FilledConst_Failing))]
        public void CreatefilledConstructor_Failing(string Firstname, string Lastname, string Errormsg)
        {
            Person p;

            Exception ex = Assert.Throws<Exception>(() => p = new Person(Firstname, Lastname));

            Assert.Equal(ex.Message, Errormsg);
        }



        [Fact]
        public void CreateProperties_Passing()
        {
            Person p = new Person()
            {
                FirstName = firstname,
                LastName = lastname
            };

            Assert.Equal(firstname, p.FirstName);
            Assert.Equal(lastname, p.LastName);

            Assert.Equal($"{firstname} {lastname}", p.ToString());
        }

        [Theory]
        [MemberData(nameof(FilledConst_Failing))]
        public void CreateProperties_Failing(string Firstname, string Lastname, string Errormsg)
        {
            Person p;

            Exception ex = Assert.Throws<Exception>(() => p = new Person()
            {
                FirstName = Firstname,
                LastName = Lastname
            });

            Assert.Equal(ex.Message, Errormsg);
        }

    }
}
