export class DefaultRentalPolicy {
  calculateDueDate(user, rentedOn) {
    const days = user.maxActiveRentals > 3 ? 21 : 14;
    const dueDate = new Date(rentedOn);
    dueDate.setDate(dueDate.getDate() + days);
    return dueDate;
  }
}
