using System;

namespace PetLib
{
    /// <summary>
    /// This partial class component contains only field
    /// </summary>
    public abstract partial class Pet:IPet, IMeal // implementation of interface
    {
        int id;
        /// <summary>
        /// This property is returing the value of private field 'id' and also allows to set its value
        /// </summary>
        /// <value>int id</value>
        public int Id{
            get{
                return id;
            }
            set{
                id=value;
            }
        }
        Gender gender;
        public Gender Gender { 
            get{
                return gender;
            }
            set{
                gender = value;
            } 
            }
        DateTime dob;
        public DateTime Dob { 
            get{
                return dob;
            } 
            set{
                dob=value;
                }
            }
        string name;
        public string Name { 
            get{return name;} 
            set{name = value;}
        }
        public partial void Partial_Method(){
            System.Console.WriteLine("World");
        }
        
    }   
    public enum Gender
    {
        Male =1, Female
    }
}
