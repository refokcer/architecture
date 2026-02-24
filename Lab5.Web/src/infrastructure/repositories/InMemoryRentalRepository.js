export class InMemoryRentalRepository {
  constructor() {
    this.rentals = [];
  }

  getActiveRentalsCountForUser(userId) {
    return this.rentals.filter((r) => r.userId === userId).length;
  }

  getActiveRentalsCountForBook(bookId) {
    return this.rentals.filter((r) => r.bookId === bookId).length;
  }

  add(rental) {
    this.rentals.push(rental);
  }
}
