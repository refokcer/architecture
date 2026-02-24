import { Book } from '../../domain/entities/Book.js';

export class InMemoryBookRepository {
  constructor() {
    this.books = [
      new Book('b1', 'Clean Code', 'Robert C. Martin', 2),
      new Book('b2', 'Refactoring', 'Martin Fowler', 1),
      new Book('b3', 'Design Patterns', 'Gang of Four', 3)
    ];
  }

  getAll() {
    return this.books;
  }

  getById(id) {
    return this.books.find((book) => book.id === id) ?? null;
  }
}
