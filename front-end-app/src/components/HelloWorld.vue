<template>
  <div class="hello">
    <h1>{{ props.hostname }}</h1>
    <DataTableCustom :value="employees" stripedRows tableStyle="min-width: 50rem">
      <ColumnCustom field="name" header="name"></ColumnCustom>
      <ColumnCustom field="departmentName" header="departmentName"></ColumnCustom>
      <ColumnCustom field="salary" header="salary"></ColumnCustom>
      <ColumnCustom field="birthday" header="birthday"></ColumnCustom>
      <ColumnCustom field="dateOfEmployment" header="dateOfEmployment"></ColumnCustom>
    </DataTableCustom>
    <ButtonCustom type="button" class="btn btn-success" @click="loadData()">Success</ButtonCustom>
    <ButtonCustom label="Danger" severity="danger" @click="clearData()"/>
  </div>
</template>

<script lang="ts">
import axios from 'axios';
import { ref, defineComponent, onMounted, computed } from 'vue';

type User = {
  id: number;
  departmentId: number;
  name: string;
  departmentName: string;
  salary: number;
  birthday: Date;
  dateOfEmployment: Date;
};

export default defineComponent({
  compatConfig: { MODE: 3 },
  name: 'HelloWorld',
  props: {
    hostname: String,
  },
  setup(props) {
    var employees = ref(null as User[] | null)

    const loadData = async () => {
      const {data, status} = await axios.get<User[]>('https://localhost:44300/company/employees')
      employees.value = data;
    }

    const clearData = () => {
      employees.value = [];
    }

    return {
      props,
      employees,
      loadData,
      clearData
    }
  },
});
</script>
<style scoped>
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
