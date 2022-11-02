import Student from './student.model';

export default class Course {
  id?: number;
  courseName = '';
  creditHours = 0;
  students?: Student[];
}
