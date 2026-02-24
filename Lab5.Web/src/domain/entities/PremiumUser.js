import { LibraryUser } from './LibraryUser.js';

export class PremiumUser extends LibraryUser {
  get maxActiveRentals() {
    return 7;
  }
}
