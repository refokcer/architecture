import { RentalRecord } from '../../domain/entities/RentalRecord.js';

export class RentalService {
  constructor(bookRepository, userRepository, rentalRepository, availabilityService, rentalPolicy, notificationService) {
    this.bookRepository = bookRepository;
    this.userRepository = userRepository;
    this.rentalRepository = rentalRepository;
    this.availabilityService = availabilityService;
    this.rentalPolicy = rentalPolicy;
    this.notificationService = notificationService;
  }

  rentBook(userId, bookId, rentedOn = new Date()) {
    const user = this.userRepository.getById(userId);
    if (!user) throw new Error('Користувача не знайдено');

    const book = this.bookRepository.getById(bookId);
    if (!book) throw new Error('Книгу не знайдено');

    if (!this.availabilityService.isAvailable(bookId)) {
      throw new Error('Книга недоступна');
    }

    const activeUserRentals = this.rentalRepository.getActiveRentalsCountForUser(userId);
    if (activeUserRentals >= user.maxActiveRentals) {
      throw new Error('Досягнуто ліміт оренд для користувача');
    }

    const dueDate = this.rentalPolicy.calculateDueDate(user, rentedOn);
    const rental = new RentalRecord(crypto.randomUUID(), userId, bookId, rentedOn, dueDate);

    this.rentalRepository.add(rental);
    this.notificationService.notifyRentalCreated(user, book, dueDate);

    return rental;
  }
}
