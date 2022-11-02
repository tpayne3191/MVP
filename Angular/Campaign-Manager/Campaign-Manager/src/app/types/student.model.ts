export default class Student {
  id?: number;
  firstName = '';
  lastName = '';
  classYear = '❓';
  get fullName(): string {
    return `${this.firstName} ${this.lastName}`;
  }
}
