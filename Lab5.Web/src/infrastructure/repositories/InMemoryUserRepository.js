import { StandardUser } from '../../domain/entities/StandardUser.js';
import { PremiumUser } from '../../domain/entities/PremiumUser.js';

export class InMemoryUserRepository {
  constructor() {
    this.users = [
      new StandardUser('u1', 'Оксана'),
      new PremiumUser('u2', 'Максим')
    ];
  }

  getAll() {
    return this.users;
  }

  getById(id) {
    return this.users.find((user) => user.id === id) ?? null;
  }
}
