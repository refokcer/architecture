export class RentalRecord {
  constructor(id, userId, bookId, rentedOn, dueDate) {
    this.id = id;
    this.userId = userId;
    this.bookId = bookId;
    this.rentedOn = rentedOn;
    this.dueDate = dueDate;
  }
}
