class Account {
    double balance;
    
    public Account(double balance) {
        this.balance = balance;
    }

    public double getBalance() {
        return balance;
    }
    
    public void Deposit(double money) {
        this.balance += money;
    }

    public void Withdraw(double money) {
        this.balance -= money;
    }
}