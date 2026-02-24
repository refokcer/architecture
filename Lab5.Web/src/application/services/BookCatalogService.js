export class BookCatalogService {
  constructor(bookRepository, rentalRepository) {
    this.bookRepository = bookRepository;
    this.rentalRepository = rentalRepository;
  }

  search(query) {
    const q = query.trim().toLowerCase();
    if (!q) return [];

    return this.bookRepository
      .getAll()
      .filter((book) => book.title.toLowerCase().includes(q) || book.author.toLowerCase().includes(q));
  }

  isAvailable(bookId) {
    const book = this.bookRepository.getById(bookId);
    if (!book) return false;

    return this.rentalRepository.getActiveRentalsCountForBook(bookId) < book.totalCopies;
  }
}
