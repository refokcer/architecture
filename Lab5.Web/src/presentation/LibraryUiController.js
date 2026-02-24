export class LibraryUiController {
  constructor({ searchService, rentalService, bookRepository, userRepository, logFn }) {
    this.searchService = searchService;
    this.rentalService = rentalService;
    this.bookRepository = bookRepository;
    this.userRepository = userRepository;
    this.logFn = logFn;
  }

  init() {
    const userSelect = document.getElementById('userSelect');
    const bookSelect = document.getElementById('bookSelect');
    const searchInput = document.getElementById('searchInput');
    const searchBtn = document.getElementById('searchBtn');
    const booksList = document.getElementById('booksList');
    const rentBtn = document.getElementById('rentBtn');
    const rentResult = document.getElementById('rentResult');

    this.userRepository.getAll().forEach((user) => {
      const option = document.createElement('option');
      option.value = user.id;
      option.textContent = `${user.name} (ліміт: ${user.maxActiveRentals})`;
      userSelect.append(option);
    });

    this.bookRepository.getAll().forEach((book) => {
      const option = document.createElement('option');
      option.value = book.id;
      option.textContent = `${book.title} — ${book.author}`;
      bookSelect.append(option);
    });

    searchBtn.addEventListener('click', () => {
      booksList.innerHTML = '';
      const results = this.searchService.search(searchInput.value);
      if (!results.length) {
        booksList.innerHTML = '<li>Нічого не знайдено</li>';
        return;
      }

      results.forEach((book) => {
        const li = document.createElement('li');
        const available = this.searchService.isAvailable(book.id) ? 'доступна' : 'недоступна';
        li.textContent = `${book.title} — ${book.author} (${available})`;
        booksList.append(li);
      });
    });

    rentBtn.addEventListener('click', () => {
      try {
        const rental = this.rentalService.rentBook(userSelect.value, bookSelect.value, new Date());
        rentResult.textContent = `Оренду створено: ${rental.id}`;
      } catch (error) {
        rentResult.textContent = `Помилка: ${error.message}`;
      }
    });

    this.logFn('Інтерфейс ініціалізовано');
  }
}
