using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using efTest2.Common;


namespace efTest2.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {

    }

    class Contact_Metadata
    {
        //Might want to use range here to control number of letters. 

       // [MailValidation]
        [StringLength(50)]
        [Required(ErrorMessage = "Förnamn måste anges")]
        [DisplayName("LastName")]
        public string LastName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }

        [StringLength(50)]
        [Required(ErrorMessage = "Förnamn måste anges")]
        public string FirstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }

        //Put a data annotation that requires a certain format here. 
        //Testa alla stringlength attribut
        [StringLength(50)]
        [Required(ErrorMessage = "Email måste anges")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$")]
        
        public string EmailAddress
        {
            get
            {
                return EmailAddress;
            }
            set
            {
                EmailAddress = value;
            }
        }

        public int ContactID
        {
            get
            {
                return ContactID;
            }
            set
            {
                ContactID = value;
            }
        }
    }
}
