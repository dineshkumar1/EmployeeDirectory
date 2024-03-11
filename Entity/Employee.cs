using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class Employee {

        
        private int _id;
        private string? _firstName;
        private string? _lastName;
        private string? _middelName;

        [Key]
        public int Id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }

        public string FirstName {
            get {
                return _firstName;
            }
            set {
                _firstName = value;
            }
        }

        public string MiddleName {
            get {
                return _middelName;
            }
            set {
                _middelName = value;
            }
        }
        public string LastName {
            get {
                return _lastName;
            }
            set {
                _lastName = value;
            }
        }
    }
}
