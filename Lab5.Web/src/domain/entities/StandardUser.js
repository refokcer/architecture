import { LibraryUser } from './LibraryUser.js';

export class StandardUser extends LibraryUser {
  get maxActiveRentals() {
    return 3;
  }
}
