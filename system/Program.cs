
using HospitalSystem.Service;

IHospitalService ihospitalService = new HospitalService();


while (true)
{
    Console.WriteLine("1.Get all patients");
    Console.WriteLine("2.Get atient by id");
    Console.WriteLine("3.Add patient");
    Console.WriteLine("4.update patient");
    Console.WriteLine("5.deletePatient()");
    Console.WriteLine("6.Get appointment by id");
    Console.WriteLine("7.getAppointmentsForDoctor");
    Console.WriteLine("8.getAppointmentsForPatient");
    Console.WriteLine("9.scheduleAppointment");
    Console.WriteLine("10.updateAppointment");
    Console.WriteLine("11.cancelAppointment");

    Console.WriteLine("Enter choice");
    int choice=int.Parse(Console.ReadLine());



    switch (choice)
    {
        case 1:
            ihospitalService.getAllPatients();
            break;
        case 2:
            ihospitalService.getPatientById();
            break;
        case 3:
            ihospitalService.addPatient();
            break;
            case 4:
            ihospitalService.updatePatient();
            break;
        case 5:
            ihospitalService.deletePatient();
                break;
        case 6:
            ihospitalService.apptmntById();
            break;
        case 7:
            ihospitalService.getAppointmentsForDoctor();
            break;
        case 8:
            ihospitalService.getAppointmentsForPatient();
            break;
        case 9:
            ihospitalService.scheduleAppointment();
            break;
            case 10:
                ihospitalService.updateAppointment();
                    break;
        case 11:
            ihospitalService.cancelAppointment();
            break;
        default:

            Console.WriteLine("enter correct choice");
            break;
    }


}
