using Org.BouncyCastle.Ocsp;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Data
{
    public class DataInitial
    {
        public static void Initialize(DataContext dataContext)
        {
            dataContext.Database.EnsureCreated();
            if (dataContext.Usuarios.Any())
            {
                return;
            }
            try
            { //Crear datos para Estados
                var dataEstados = new Models.Estados[]
                {
                new() {
                    EstName="Activo",
                    EstCategory= "Usuarios",
                    EstColor="#26ce08",

                },
                new ()
                {
                    EstName="Inactivo",
                    EstCategory= "Usuarios",
                    EstColor="#ff0000"
                },
                };
                dataContext.Estados.AddRange(dataEstados);
                dataContext.SaveChanges();

                //Crear datos para Roles
                var dataRoles = new Models.Roles[]
                {
                new() {
                    RolName = "Administrador",
                    RolDescription="Area de Desarrollo"
                },
                new() {
                    RolName = "Cliente",
                    RolDescription="Cliente registrado en portal",
                }
                };
                dataContext.Roles.AddRange(dataRoles);
                dataContext.SaveChanges();

                //Crear datos para Usuarios
                var dataUsuarios = new Models.Usuarios[]
                {
                    new() {
                    UsuName="Ruben Dario",
                    UsuLastName="Carrillo Lopez",
                    UsuTypeDni="CI",
                    UsuNumDni="1718321902",
                    UsuNumPhone="0984322045",
                    UsuEmail="rubendario921@hotmail.com",
                    UsuPassword="12345678",
                    UsuAttempts=0,
                    UsuAdicionalArchive=null,
                    UsuProfilePicture=null,
                    EstId=1,
                    RolId=1,
                    },
                    new() {
                    UsuName="Wladimir",
                    UsuLastName="Campaña",
                    UsuTypeDni="CI",
                    UsuNumDni="1715963326",
                    UsuNumPhone="0998758533",
                    UsuEmail="wladycampana@hotmail.com",
                    UsuPassword="Wlady123",
                    UsuAttempts=0,
                    UsuAdicionalArchive=null,
                    UsuProfilePicture=null,
                    EstId=1,
                    RolId=2,
                    },
                    new() {
                    UsuName="John",
                    UsuLastName="Velasco",
                    UsuTypeDni="CI",
                    UsuNumDni="1752264976",
                    UsuNumPhone="0997851292",
                    UsuEmail="jvelasco@selecciontalento.com",
                    UsuPassword="12345678",
                    UsuAttempts=0,
                    UsuAdicionalArchive=null,
                    UsuProfilePicture=null,
                    EstId=1,
                    RolId=1,
                    },
                };
                dataContext.Usuarios.AddRange(dataUsuarios);
                dataContext.SaveChanges();

                //Ingreso de valores Industrias
                var dataIndustria = new Models.Industrias[] {
                    new(){IndName = "Talento Humano", IndDetails ="Manejo del personal",
                    },
                    new()
                    {                        IndName = "Tecnología", IndDetails ="Desarrollo de Software"
                    }
                };
                dataContext.Industrias.AddRange(dataIndustria);
                dataContext.SaveChanges();

                //INgreso de valores Cantidad de Empleados
                var dataCantidadEmpleados = new Models.CantidadEmpleados[] {
                    new(){
                        CantEmpDetails="Entre 0 a 5 personas"
                    },
                    new(){                        
                        CantEmpDetails="Entre 5 a 10 personas"
                    },
                };
                dataContext.CantidadEmpleados.AddRange(dataCantidadEmpleados);
                dataContext.SaveChanges();

                //Ingresos de valores Empresas
                var dataEmpresas = new Models.Empresas[]
                {
                    new ()
                    {
                        EmpStaffName="Ruben Dario",
                        EmpStaffLastName="Carrillo Lopez",
                        EmpStaffEmail="rcarrillo@selecciontalento.com",
                        EmpStaffPassword="12345678",
                        EmpName="Seleccion Talento",
                        EmpRazonSocial="Consultoria y atención al cliente",
                        EmpNumRuc="1718321902",
                        EmpDireccion="Yacuambi y Av. La prensa",
                        EmpCodPostal="123456",
                        EmpNumPhone="0984322045",
                        EmpProfilePicture=null,
                        EstId=1,
                        CantEmpId=1,
                        IndId=1,

                    },
                };
                dataContext.Empresas.AddRange(dataEmpresas);
                dataContext.SaveChanges();

                //Ingresos de valores a Modalidades
                var dataModalidad = new Models.Modalidades[] {
                    new()
                    {
                        ModName = "Presencial",
                        ModInformacion = "Se necesita de presencia fisica para realizar las actividades",
                    }, };
                dataContext.Modalidades.AddRange(dataModalidad);
                dataContext.SaveChanges();

                //Ingreso de valores Idiomas
                var dataIdiomas = new Models.Idiomas[] {
                    new(){IdiName= "Ingles"} };
                dataContext.Idiomas.AddRange(dataIdiomas);
                dataContext.SaveChanges();

                //Ingreso data Cantidatos
                var dataCandidatos = new Models.Candidatos[] { new() {
                    CanNombre="Ruben Dario",
                    CanApellido= "Carrillo Lopez",
                    CanNacionalidad="Ecuatoriano",
                    CanTipoDni="CI",
                    CanNumDni="1718321902",
                    CanPassword="12345678",
                    CanEstadoCivil="Soltero",
                    CanGenero="Masculino",
                } };
                dataContext.Candidatos.AddRange(dataCandidatos);
                dataContext.SaveChanges();

                //Ingreso datos CandidatosIdioma
                var dataCandidatosIdioma = new Models.CandidatoIdioma[] {new(){
                    IdiId=1,
                    CanId=1,
                    CanIdiNivelEscrito="Basico",
                    CanIdiNivelOral="Basico"
                } };
                dataContext.CandidatoIdiomas.AddRange(dataCandidatosIdioma);
                dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar datos: {ex.Message}");
            }
        }
    }
}
