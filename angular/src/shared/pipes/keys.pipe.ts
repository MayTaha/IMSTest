import { Pipe, PipeTransform } from "@angular/core";

@Pipe({name: 'keys'})
export class KeysPipe implements PipeTransform {
  transform(value) : any {
    let keys = [];
    for (var enumMember in value) {
      if (!isNaN(parseInt(enumMember, 10))) {
        keys.push({key: parseInt(enumMember), value: value[enumMember]});
      } 
    }
    return keys;
  }
}