module MVVM {
    export class Student {
        Id: Number;
        Name: string;
        Email: string;
        Dob: Date;
        Address: string;
        Phone: string;
        IsVisibleSave: boolean;
        IsVisibleUpdate: boolean;
        IsVisibleDelete: boolean;
    }
     
    export class Subject {
        Id: number;
        Name: number;
        Fee: number;
    }
    export class StudentSubject {
        StudentId: number;
        SubjectId: number;
        RegDate: number;
    }
 

}
