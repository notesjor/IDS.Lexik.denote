<template>
  <div>
      {{ emoji }} - {{ message }}
  </div>
</template>

<script>
export default {

  data() {
    return {
      emoji: '😥',
      message: 'oh nein!'
    }
  },
}
</script>