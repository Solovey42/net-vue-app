<template>
  <div class="hello">
    <h1>{{ props.hostname }}</h1>
    <DataTableCustom :value="employees" stripedRows tableStyle="min-width: 50rem">
      <ColumnCustom class="colum" v-for="col of columns" :key="col.field" :field="col.field" :header="col.header" :visible="col.visible">
        <template v-if="col.field == 'birthday' || col.field == 'dateOfEmployment'" #body="{ data, field }">
          {{ convertDate(data[field]) }}
        </template>
        <template v-else #body="{ data, field }">
          {{ data[field] }}
        </template>
      </ColumnCustom>
    </DataTableCustom>
    <ButtonCustom type="button" class="btn btn-success" @click="loadData()">Success</ButtonCustom>
    <ButtonCustom label="Danger" severity="danger" @click="clearData()"/>
  </div>
</template>

<script lang="ts">
import axios from 'axios';
import { DateTime } from "luxon";
import { ref, defineComponent } from 'vue';

type User = {
  id: number;
  departmentId: number;
  name: string;
  departmentName: string;
  salary: number;
  birthday: DateTime;
  dateOfEmployment: DateTime;
};

export default defineComponent({
  compatConfig: { MODE: 3 },
  name: 'HelloWorld',
  props: {
    hostname: String,
  },
  setup(props) {
    var employees = ref(null as User[] | null)

    const columns = [
      { field: 'name', header: 'ФИО', visible: true },
      { field: 'departmentName', header: 'Подразделение', visible: true  },
      { field: 'salary', header: 'Зарплата', visible: true  },
      { field: 'birthday', header: 'Дата рождения', visible: true  },
      { field: 'dateOfEmployment', header: 'Дата устройства на работу', visible: true  }
    ];

    const loadData = async () => {
      console.log('date');
      const {data, status} = await axios.get<User[]>('https://localhost:44300/company/employees')
      employees.value = data;
    }

    const clearData = () => {
      employees.value = [];
    }

    const convertDate = (date: DateTime) => {
      console.log(date.toFormat('dd-mm-yyyy'));
      if (date) return date;
      return;
    }

    return {
      props,
      employees,
      columns,
      loadData,
      clearData,
      convertDate
    }
  },
});
</script>
<style scoped>
.column{
  margin-left: 30px;
}

h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
