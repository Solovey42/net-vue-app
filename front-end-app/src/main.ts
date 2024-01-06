import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import VueAxios from 'vue-axios'
import axios from 'axios'
import PrimeVue from 'primevue/config';
import 'primevue/resources/themes/md-dark-indigo/theme.css'
import 'primevue/resources/primevue.min.css'
import Button from 'primevue/button'
import Checkbox from 'primevue/checkbox';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import ColumnGroup from 'primevue/columngroup';   
import Row from 'primevue/row';   
import Calendar from 'primevue/calendar';

const app = createApp(App)
app.config.globalProperties.hostname = "https://localhost:44354"
app.use(store)
app.use(router)
app.use(VueAxios, axios)
app.use(PrimeVue)
app.component('ButtonCustom', Button)
app.component('CheckboxCustom', Checkbox)
app.component('DataTableCustom', DataTable)
app.component('ColumnCustom', Column)
app.component('ColumnGroupCustom', ColumnGroup)
app.component('RowCustom', Row)
app.component('CalendarCustom', Calendar)
app.mount('#app')

