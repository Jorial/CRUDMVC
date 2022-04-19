using CRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;
using CRUDMVC.Datos;
using System.Data;

namespace CRUDMVC.Controllers
{
    public class ContactController : Controller
    {
        ContactoDatos contactD = new ContactoDatos();
        public IActionResult SaveContactControler()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveContactControler(ContactModel conmol)
        {
            //Validamos los campos
            if (!ModelState.IsValid) return View();           


            //Este metodo recibe los paramentro para guardarlos en la db
            contactD.SaveContact(conmol);

            // Retornamos la vista de contactos
            if(contactD.SaveContact != null)
            {
                return RedirectToAction("GetAllContactCtr");
            }
            else
            {
                return View();
            }
           
        }

        [HttpGet]
        public IActionResult GetAllContactCtr()
        {
            

            //DataTable dataTable = contactD.GetAllContat().Tables["ContactosTable"];
            DataTable dataTable = contactD.GetAllContat().Tables[0];
            
            return View(dataTable);
        }

        // Update

        public IActionResult UpdateContatControl(int Id)
        {
            DataTable dt = contactD.GetOnlyOneContat(Id).Tables[0];
            ContactModel contact = new ContactModel();
            foreach (DataRow item in dt.Rows)
            {
                contact.Idcontacto = @Convert.ToInt32(item[0]);
                contact.Nombre = @Convert.ToString(item[1]);
                contact.Telefono = @Convert.ToInt32(item[2]);
            }
            return View(contact);

        }

        [HttpPost]
        public IActionResult UpdateContatControl(ContactModel contact)
        {
          

            contactD.UpdateContact(contact);
          

            // Retornamos la vista de contactos
            if (contactD.UpdateContact != null)
            {
                return RedirectToAction("GetAllContactCtr");
            }
            else
            {
                return View();
                 
            };
               
        }

            //Creamos 2 Metodos, el Primero es para Mostar la vista y el segundo es para ejectuar la eliminacion

            public IActionResult DeleteContactCtr(int Id)
        {
            DataTable dt = contactD.GetOnlyOneContat(Id).Tables[0];
            ContactModel cm = new ContactModel();

            foreach (DataRow item in dt.Rows)
            {
                cm.Idcontacto = Convert.ToInt32(item[0]);
                cm.Nombre = Convert.ToString(item[1]);
                cm.Telefono = Convert.ToInt32(item[2]);
            }

            return View(cm);
            
        }

        [HttpPost]
        public IActionResult DeleteContactCtr(ContactModel cm)
        {
            //if (!ModelState.IsValid) return View();
            contactD.DeleteContact(cm);
            if (contactD.DeleteContact != null)
                return RedirectToAction("GetAllContactCtr");
            else                        
                return View();
        }
    }
}

