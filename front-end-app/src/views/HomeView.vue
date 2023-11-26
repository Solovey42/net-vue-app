<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld msg="Чисто приложунька"/>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import HelloWorld from '@/components/HelloWorld.vue';

export default defineComponent({
  name: 'HomeView',
  components: {
    HelloWorld,
  },
});
</script>
