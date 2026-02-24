import { BookCatalogService } from './application/services/BookCatalogService.js';
import { RentalService } from './application/services/RentalService.js';
import { InMemoryBookRepository } from './infrastructure/repositories/InMemoryBookRepository.js';
import { InMemoryUserRepository } from './infrastructure/repositories/InMemoryUserRepository.js';
import { InMemoryRentalRepository } from './infrastructure/repositories/InMemoryRentalRepository.js';
import { UiNotificationService } from './infrastructure/notifications/UiNotificationService.js';
import { DefaultRentalPolicy } from './infrastructure/policies/DefaultRentalPolicy.js';
import { LibraryUiController } from './presentation/LibraryUiController.js';

const logs = document.getElementById('logs');
const logFn = (message) => {
  const li = document.createElement('li');
  li.textContent = `[${new Date().toLocaleTimeString('uk-UA')}] ${message}`;
  logs.prepend(li);
};

const bookRepository = new InMemoryBookRepository();
const userRepository = new InMemoryUserRepository();
const rentalRepository = new InMemoryRentalRepository();

const searchService = new BookCatalogService(bookRepository, rentalRepository);
const rentalPolicy = new DefaultRentalPolicy();
const notificationService = new UiNotificationService(logFn);
const rentalService = new RentalService(
  bookRepository,
  userRepository,
  rentalRepository,
  searchService,
  rentalPolicy,
  notificationService
);

new LibraryUiController({
  searchService,
  rentalService,
  bookRepository,
  userRepository,
  logFn
}).init();
