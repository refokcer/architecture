export class LibraryUser {
  constructor(id, name) {
    this.id = id;
    this.name = name;
  }

  get maxActiveRentals() {
    throw new Error('Must be implemented in subclass');
  }
}
