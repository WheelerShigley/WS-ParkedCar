class ParkingTicket {
    //instance variables (parallel arrays)
    int fee_dollars; short fee_cents;

    //constructor
    public ParkingTicket() { fee_dollars = 0; fee_cents = (Int16)(0); }

    //getters
    public double getFee() {
        double temp = 0.0d;
        temp += (double)(fee_dollars); temp += (double)(fee_cents)/100.0d;
        return temp;
    }

    //setters
    public void setFee(int dollars, short cents) {
        this.fee_dollars = dollars;
        this.fee_cents = cents;
    }

    //other methods
    public void chargeCar() { fee_dollars = 25; }

    private void addCents(short cent_count) {
        fee_cents += cent_count;
        fee_dollars += cent_count/100;
        fee_cents %= 100;
    }

    public void violationFee() {
        addCents( (Int16)(16) );
    }
}