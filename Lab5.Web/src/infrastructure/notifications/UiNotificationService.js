export class UiNotificationService {
  constructor(logFn) {
    this.logFn = logFn;
  }

  notifyRentalCreated(user, book, dueDate) {
    this.logFn(`✅ ${user.name} орендував(ла) "${book.title}" до ${dueDate.toLocaleDateString('uk-UA')}`);
  }
}
