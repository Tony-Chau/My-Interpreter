import * as loadIniFile from "read-ini-file";
import { join } from "path";
var json = loadIniFile.sync("./../../../key.ini");

export class keys{
  Yandex = json.Yandex.key;
  RapidHost = json.Rapid.host;
  RapidKey = json.Rapid.key;
}
