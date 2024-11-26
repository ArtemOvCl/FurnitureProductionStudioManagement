import { Pipe, PipeTransform } from '@angular/core';
import { CurrencyService } from '../../Services/currency.service';

@Pipe({
  name: 'currencyConverter',
  pure: false,
  standalone: true
})
export class CurrencyConverterPipe implements PipeTransform {
  private rates: { [key: string]: number } = {};
  private isRatesLoaded = false;

  constructor(private currencyService: CurrencyService) {
    this.loadRates();
  }

  private loadRates(): void {
    this.currencyService.getRates().subscribe((data: any[]) => {
      data.forEach((item) => {
        this.rates[item.cc] = item.rate; 
      });
      this.isRatesLoaded = true;
    });
  }

  transform(value: number, targetCurrency?: string): string {
    if (!value) {
      return 'Invalid amount';
    }

    if (!this.isRatesLoaded) {
      return 'Loading rates...';
    }

    if (targetCurrency) {

      const rate = this.rates[targetCurrency];

      if (!rate) {
        return 'Currency not supported';
      }

      const convertedValue = (value / rate).toFixed(2);
      return `${convertedValue} ${targetCurrency}`;
    } else {

      return Object.entries(this.rates)
        .map(([currency, rate]) => `${(value * rate).toFixed(2)} ${currency}`)
        .join('\n');
    }
  }
}
